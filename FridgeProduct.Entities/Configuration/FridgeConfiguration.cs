using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class FridgeConfiguration : IEntityTypeConfiguration<Fridge>
    {
        public void Configure(EntityTypeBuilder<Fridge> builder)
        {
            builder.HasData(
                new Fridge
                {
                    Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                    Name = "Holod",
                    OwnerName = "Aleks",
                    ModelId = new Guid("745cff18-3dfe-4c44-8eb9-5bd6c3e8f328"),
                    ProductId = 1
                },
                new Fridge
                {
                    Id = new Guid("5df63d42-598e-4b30-8493-8fd0c6cdaf18"),
                    Name = "Moroz",
                    OwnerName = "Viktor",
                    ModelId = new Guid("41914da1-1deb-47d2-bf06-92e71952b7d4"),
                    ProductId = 2
                }
            );
        }
    }
}
