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
                    ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf51"),
                    FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                    Quantity = 10
                },
                new FridgeToProduct
                {
                    ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf52"),
                    FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                    Quantity = 2
                },
                new FridgeToProduct
                {
                    ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf53"),
                    FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                    Quantity = 2
                },
                new FridgeToProduct
                {
                    ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf54"),
                    FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                    Quantity = 2
                },
                new FridgeToProduct
                {
                    ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf55"),
                    FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                    Quantity = 2
                },
                new FridgeToProduct
                {
                    ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf56"),
                    FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                    Quantity = 2
                },
                new FridgeToProduct
                {
                    ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf57"),
                    FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                    Quantity = 2
                },
                new FridgeToProduct
                {
                    ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf51"),
                    FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"),
                    Quantity = 10
                },
                new FridgeToProduct
                {
                    ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf56"),
                    FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"),
                    Quantity = 2
                },
                new FridgeToProduct
                {
                    ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf57"),
                    FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"),
                    Quantity = 2
                },
                new FridgeToProduct
                {
                    ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf58"),
                    FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"),
                    Quantity = 2
                },
                new FridgeToProduct
                {
                    ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf59"),
                    FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"),
                    Quantity = 2
                },
                new FridgeToProduct
                {
                    ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf60"),
                    FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"),
                    Quantity = 2
                },
                new FridgeToProduct
                {
                    ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf61"),
                    FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"),
                    Quantity = 2
                },
                new FridgeToProduct
                {
                    ProductId = new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf58"),
                    FridgeId = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                    Quantity = 2
                }
                );
        }
    }
}
