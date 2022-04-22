using FridgeProduct.Entities.Configuration;
using FridgeProduct.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading;
using RabbitMQ.Client;
using Newtonsoft.Json;
using FridgeProduct.Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Reflection;

namespace FridgeProduct.Entities
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RepositoryContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FridgeModel> FridgeModels { get; set; }
        public DbSet<FridgeToProduct> FridgeToProducts { get; set; }
        public DbSet<FileModel> Files { get; set; }
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
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FridgeProduct;Trusted_Connection=True");
            optionsBuilder.LogTo(Console.WriteLine);
        }

        public Task<int> SaveChangesAuditable()
        {
            ChangeTracker.DetectChanges();
            var ent = new List<Auditable>();
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            /*var entities = ChangeTracker.Entries().Select(c=>new Auditable() { 
                Changed = DateTime.Now, 
                EntityName = c.Entity.GetType().Name, 
                Operation = c.State.ToString(),
                UserId = userId
                //OldData
                //NewData = c.CurrentValues.GetValue(c).ToString()
            });*/

            var modifiedEntities = ChangeTracker.Entries()
            .Where(p => p.State == EntityState.Modified || p.State == EntityState.Added || p.State == EntityState.Deleted || p.State == EntityState.Modified || p.State == EntityState.Detached).ToList();
            var now = DateTime.UtcNow;

            foreach (var change in modifiedEntities)
            {
                var entityName = change.Entity.GetType().Name;
                foreach (var prop in change.Entity.GetType().GetTypeInfo().DeclaredProperties)
                {
                    if (change.Property(prop.Name).IsModified)
                    {
                        var changeLoged = new Auditable
                        {
                            Operation = change.State.ToString(),
                            EntityName = entityName,
                            Changed = DateTime.Now,
                            OldData = change.OriginalValues.ToString(),
                            NewData = change.CurrentValues.ToString(),
                            UserId = userId
                        };
                    }
                }
            }

            // должна быть одна фэктори
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
            return base.SaveChangesAsync();
        }
    }
}
