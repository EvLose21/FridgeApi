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
    public class FridgeToProductConfiguration : IEntityTypeConfiguration<FridgeToProduct>
    {
        public void Configure(EntityTypeBuilder<FridgeToProduct> builder)
        {
            builder.HasData(
                new FridgeToProduct
                {
                    ProductId = new Guid("14ad7a49-95f6-4e96-9c29-c3080ec493d0"),
                    FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                    Quantity = 10
                },
                new FridgeToProduct
                {
                    ProductId = new Guid("962be0f6-a4a3-4e17-bf3e-1ea1b7e029d3"),
                    FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                    Quantity = 1100
                }
                );
        }
    }
}
