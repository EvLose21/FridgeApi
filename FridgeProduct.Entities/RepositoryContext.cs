using FridgeProduct.Entities.Configuration;
using FridgeProduct.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading;
using RabbitMQ.Client;
using Newtonsoft.Json;
using FridgeProduct.Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using FridgeProduct.Entities.Services;

namespace FridgeProduct.Entities
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        private readonly IGetUserId _getId;
        private bool _isAuditable;
        public RepositoryContext(DbContextOptions options, IGetUserId getId)
            : base(options)
        {
            _isAuditable = true;
            _getId = getId;
        }

        public RepositoryContext(DbContextOptions options, bool isAuditable)
            : base(options)
        {
            _isAuditable = isAuditable;
        }
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FridgeModel> FridgeModels { get; set; }
        public DbSet<FridgeToProduct> FridgeToProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FridgeConfiguration());
            modelBuilder.ApplyConfiguration(new FridgeModelConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new FridgeToProductConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder
                .Entity<Fridge>()
                .HasMany(f => f.Products)
                .WithMany(p => p.Fridges)
                .UsingEntity<FridgeToProduct>(
                   j => j
                    .HasOne(pt => pt.Product)
                    .WithMany(t => t.FridgeToProducts)
                    .HasForeignKey(pt => pt.ProductId),
                   j => j
                    .HasOne(pt => pt.Fridge)
                    .WithMany(p => p.FridgeToProducts)
                    .HasForeignKey(pt => pt.FridgeId),
                   j =>
                   {
                    j.Property(pt => pt.Quantity).HasDefaultValue(3);
                    j.HasKey(t => new { t.FridgeId, t.ProductId });
                    j.ToTable("FridgeToProduct");
                   });

            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FridgeProduct;Trusted_Connection=True");
            optionsBuilder.LogTo(Console.WriteLine);
        }

        public override int SaveChanges()
        {
            if(_isAuditable == false)
            {
                return base.SaveChanges();   
            }
                var auditEntries = ActionBeforeSaveChanges();
                var result = base.SaveChanges();
                ActionAfterSaveChanges(auditEntries);
                return result;  
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_isAuditable == false)
            {
                return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            }
                var auditEntries = ActionBeforeSaveChanges();
                var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
                await ActionAfterSaveChanges(auditEntries);
                return result;   
        }

        private List<AuditEntry> ActionBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var userId = _getId.GetUserId();
            var entries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Auditable || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                {
                    continue;
                }

                var auditEntry = new AuditEntry(entry)
                {
                    UserName = userId,
                    TableName = entry.Entity.GetType().Name
                };
                entries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary)
                    {
                        auditEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    var propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                        case EntityState.Detached:
                            break;
                        case EntityState.Unchanged:
                            break;
                    }
                }
            }

            return entries;
        }

        private Task ActionAfterSaveChanges(List<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
                return Task.CompletedTask;

            foreach (var entry in auditEntries.Where(_ => _.HasTemporaryProperties).ToList())
            {
                
                foreach (var prop in entry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        entry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                    else
                    {
                        entry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                }   
            }

            var ent = new List<Auditable>();
            foreach (var entry in auditEntries)
            {
                ent.Add(entry.ToAudit());
            }

            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("fridges", exclusive: false);

            var json = JsonConvert.SerializeObject(ent);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "fridges", body: body);
            return Task.CompletedTask;
        }
    }
}
