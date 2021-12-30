using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FridgeProduct.Entities.Migrations
{
    public partial class addInitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FridgeToProduct",
                columns: new[] { "FridgeId", "ProductId", "Quantity" },
                values: new object[] { new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"), new Guid("962be0f6-a4a3-4e17-bf3e-1ea1b7e029d3"), 1 });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "FridgeId", "FridgeModelId", "ModelId", "Name", "OwnerName" },
                values: new object[] { new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"), null, new Guid("745cff18-3dfe-4c44-8eb9-5bd6c3e8f328"), "Holodilnik", "Loser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FridgeToProduct",
                keyColumns: new[] { "FridgeId", "ProductId" },
                keyValues: new object[] { new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"), new Guid("962be0f6-a4a3-4e17-bf3e-1ea1b7e029d3") });

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "FridgeId",
                keyValue: new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"));
        }
    }
}
