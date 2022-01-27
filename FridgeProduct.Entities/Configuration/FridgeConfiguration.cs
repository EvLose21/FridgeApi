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
    public class FridgeConfiguration : IEntityTypeConfiguration<Fridge>
    {
        public void Configure(EntityTypeBuilder<Fridge> builder)
        {
            builder.HasData(
                new Fridge
                {
                    Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"),
                    Name = "One",
                    OwnerName = "First",
                    FridgeModelId = new Guid("65afe2b1-27ac-4657-865c-065d10505bef"),
                },
                new Fridge
                {
                    Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"),
                    Name = "Two",
                    OwnerName = "Second",
                    FridgeModelId = new Guid("65afe2b1-27ac-4657-865c-065d10505bef"),
                },
                new Fridge
                {
                    Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7092"),
                    Name = "Three",
                    OwnerName = "Third",
                    FridgeModelId = new Guid("7366b8d8-f4ba-4747-9806-f85bad203ef5")
                },
                new Fridge
                {
                    Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7093"),
                    Name = "Four",
                    OwnerName = "Fourth",
                    FridgeModelId = new Guid("7366b8d8-f4ba-4747-9806-f85bad203ef5")
                },
                new Fridge
                {
                    Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7094"),
                    Name = "Five",
                    OwnerName = "Fivth",
                    FridgeModelId = new Guid("7366b8d8-f4ba-4747-9806-f85bad203ef5")
                },
                new Fridge
                {
                    Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7095"),
                    Name = "Six",
                    OwnerName = "Sixth",
                    FridgeModelId = new Guid("8523783c-d082-4805-90ce-b2d32147aedb")
                },
                new Fridge
                {
                    Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7096"),
                    Name = "Seven",
                    OwnerName = "Seventh",
                    FridgeModelId = new Guid("8523783c-d082-4805-90ce-b2d32147aedb")
                },
                new Fridge
                {
                    Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7097"),
                    Name = "Eight",
                    OwnerName = "8th",
                    FridgeModelId = new Guid("8523783c-d082-4805-90ce-b2d32147aedb")
                },
                new Fridge
                {
                    Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7098"),
                    Name = "Nine",
                    OwnerName = "Ninth",
                    FridgeModelId = new Guid("ce82a987-8381-43c1-9dae-c1181da0510f")
                },
                new Fridge
                {
                    Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7099"),
                    Name = "Ten",
                    OwnerName = "Tenth",
                    FridgeModelId = new Guid("ce82a987-8381-43c1-9dae-c1181da0510f")
                },
                new Fridge
                {
                    Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7100"),
                    Name = "Eleven",
                    OwnerName = "Eleventh",
                    FridgeModelId = new Guid("ce82a987-8381-43c1-9dae-c1181da0510f")
                },
                new Fridge
                {
                    Id = new Guid("7b104622-4fef-465a-a5d4-2015de2c7102"),
                    Name = "Twelve",
                    OwnerName = "Twelfth",
                    FridgeModelId = new Guid("ce82a987-8381-43c1-9dae-c1181da0510f")
                }
            );
        }
    }
}
