using FridgeProduct.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Entities.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf51"),
                    Name = "Eggs",
                    DefaultQuantity = 1
                },
                new Product
                {
                    Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf52"),
                    Name = "Butter",
                    DefaultQuantity = 1
                },
                new Product
                {
                    Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf53"),
                    Name = "Meat",
                    DefaultQuantity = 1
                },
                new Product
                {
                    Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf54"),
                    Name = "Milk",
                    DefaultQuantity = 1
                },
                new Product
                {
                    Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf55"),
                    Name = "Kefir",
                    DefaultQuantity = 1
                },
                new Product
                {
                    Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf56"),
                    Name = "Sausage",
                    DefaultQuantity = 1
                },
                new Product
                {
                    Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf57"),
                    Name = "Ice-cream",
                    DefaultQuantity = 1
                },
                new Product
                {
                    Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf58"),
                    Name = "Cheese",
                    DefaultQuantity = 1
                },
                new Product
                {
                    Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf59"),
                    Name = "Cabbage",
                    DefaultQuantity = 1
                },
                new Product
                {
                    Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf60"),
                    Name = "Cake",
                    DefaultQuantity = 1
                },
                new Product
                {
                    Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf61"),
                    Name = "Onion",
                    DefaultQuantity = 1
                },
                new Product
                {
                    Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf62"),
                    Name = "Chicken",
                    DefaultQuantity = 1
                },
                new Product
                {
                    Id = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf63"),
                    Name = "Tomato",
                    DefaultQuantity = 1
                }
            );
        }
    }
}
