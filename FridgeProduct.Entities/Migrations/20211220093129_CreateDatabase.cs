using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FridgeProduct.Entities.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FridgeModels",
                columns: table => new
                {
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeModels", x => x.ModelId);
                });

            migrationBuilder.CreateTable(
                name: "Fridges",
                columns: table => new
                {
                    FridgeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridges", x => x.FridgeId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultQuantity = table.Column<int>(type: "int", nullable: false),
                    FridgeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "FridgeProduct",
                columns: table => new
                {
                    FridgesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeProduct", x => new { x.FridgesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_FridgeProduct_Fridges_FridgesId",
                        column: x => x.FridgesId,
                        principalTable: "Fridges",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FridgeProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FridgeModels",
                columns: new[] { "ModelId", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("65afe2b1-27ac-4657-865c-065d10505bef"), "NewModelOne", 2019 },
                    { new Guid("ce82a987-8381-43c1-9dae-c1181da0510f"), "NewModelTwo", 2019 }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "FridgeId", "ModelId", "Name", "OwnerName", "ProductId" },
                values: new object[,]
                {
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"), new Guid("745cff18-3dfe-4c44-8eb9-5bd6c3e8f328"), "Holod", "Aleks", 1 },
                    { new Guid("5df63d42-598e-4b30-8493-8fd0c6cdaf18"), new Guid("41914da1-1deb-47d2-bf06-92e71952b7d4"), "Moroz", "Viktor", 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "DefaultQuantity", "FridgeId", "ProductName" },
                values: new object[,]
                {
                    { new Guid("962be0f6-a4a3-4e17-bf3e-1ea1b7e029d3"), 1, 1, "Eggs" },
                    { new Guid("14ad7a49-95f6-4e96-9c29-c3080ec493d0"), 1, 2, "Bacon" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FridgeProduct_ProductsId",
                table: "FridgeProduct",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FridgeModels");

            migrationBuilder.DropTable(
                name: "FridgeProduct");

            migrationBuilder.DropTable(
                name: "Fridges");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
