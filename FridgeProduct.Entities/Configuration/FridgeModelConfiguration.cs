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
    public class FridgeModelConfiguration : IEntityTypeConfiguration<FridgeModel>
    {
        public void Configure(EntityTypeBuilder<FridgeModel> builder)
        {
            builder.HasData(
                new FridgeModel
                {
                    Id = new Guid("65afe2b1-27ac-4657-865c-065d10505bef"),
                    Name = "NewModelOne",
                    Year = 2019
                },
                new FridgeModel
                {
                    Id = new Guid("ce82a987-8381-43c1-9dae-c1181da0510f"),
                    Name = "NewModelTwo",
                    Year = 2019
                }
            );
        }
    }
}
