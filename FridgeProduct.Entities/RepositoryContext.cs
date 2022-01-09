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

namespace FridgeProduct.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        { 
        }
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FridgeModel> FridgeModels { get; set; }
        public DbSet<FridgeToProduct> FridgeToProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FridgeConfiguration());
            modelBuilder.ApplyConfiguration(new FridgeModelConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new FridgeToProductConfiguration());
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
    }
}
