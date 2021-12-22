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
                    Id = new Guid("962be0f6-a4a3-4e17-bf3e-1ea1b7e029d3"),
                    Name = "Eggs",
                    DefaultQuantity = 1
                },
                new Product
                {
                    Id = new Guid("14ad7a49-95f6-4e96-9c29-c3080ec493d0"),
                    Name = "Bacon",
                    DefaultQuantity = 1
                }
            );
        }
    }
}
