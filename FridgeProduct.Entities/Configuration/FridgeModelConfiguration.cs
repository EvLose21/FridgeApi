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
                    Name = "Model1",
                    Year = 2014
                },
                new FridgeModel
                {
                    Id = new Guid("7366b8d8-f4ba-4747-9806-f85bad203ef5"),
                    Name = "Model2",
                    Year = 2015
                },
                new FridgeModel
                {
                    Id = new Guid("8523783c-d082-4805-90ce-b2d32147aedb"),
                    Name = "Model3",
                    Year = 2016
                },
                new FridgeModel
                {
                    Id = new Guid("ce82a987-8381-43c1-9dae-c1181da0510f"),
                    Name = "Model1v2",
                    Year = 2018
                }
            );
        }
    }
}
