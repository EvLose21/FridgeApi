using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FridgeProduct.Entities.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

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
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fridges",
                columns: table => new
                {
                    FridgeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FridgeModelId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 60, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridges", x => x.FridgeId);
                    table.ForeignKey(
                        name: "FK_Fridges_FridgeModels_FridgeModelId",
                        column: x => x.FridgeModelId,
                        principalTable: "FridgeModels",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FridgeToProduct",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FridgeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 3)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeToProduct", x => new { x.FridgeId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_FridgeToProduct_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "FridgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FridgeToProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07b95c3b-1282-411b-a82c-cfc6394c1cfa", "98186158-e582-47ee-81ab-d7a4bbec2b60", "Administrator", "ADMINISTRATOR" },
                    { "9c722039-76c2-4e6d-9dbc-fdd4dbfed7d6", "b95926a7-14c4-4b8b-98c9-2c68b4e0d87a", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "FridgeModels",
                columns: new[] { "ModelId", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("ce82a987-8381-43c1-9dae-c1181da0510f"), "Model1v2", 2018 },
                    { new Guid("65afe2b1-27ac-4657-865c-065d10505bef"), "Model1", 2014 },
                    { new Guid("7366b8d8-f4ba-4747-9806-f85bad203ef5"), "Model2", 2015 },
                    { new Guid("8523783c-d082-4805-90ce-b2d32147aedb"), "Model3", 2016 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "DefaultQuantity", "ProductName" },
                values: new object[,]
                {
                    { new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf51"), 1, "Eggs" },
                    { new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf52"), 1, "Butter" },
                    { new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf53"), 1, "Meat" },
                    { new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf54"), 1, "Milk" },
                    { new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf55"), 1, "Kefir" },
                    { new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf57"), 1, "Ice-cream" },
                    { new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf58"), 1, "Cheese" },
                    { new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf59"), 1, "Cabbage" },
                    { new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf60"), 1, "Cake" },
                    { new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf61"), 1, "Onion" },
                    { new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf62"), 1, "Chicken" },
                    { new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf63"), 1, "Tomato" },
                    { new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf56"), 1, "Sausage" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "FridgeId", "FridgeModelId", "Name", "OwnerName" },
                values: new object[,]
                {
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"), new Guid("65afe2b1-27ac-4657-865c-065d10505bef"), "One", "First" },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"), new Guid("65afe2b1-27ac-4657-865c-065d10505bef"), "Two", "Second" },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7092"), new Guid("7366b8d8-f4ba-4747-9806-f85bad203ef5"), "Three", "Third" },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7093"), new Guid("7366b8d8-f4ba-4747-9806-f85bad203ef5"), "Four", "Fourth" },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7094"), new Guid("7366b8d8-f4ba-4747-9806-f85bad203ef5"), "Five", "Fivth" },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7095"), new Guid("8523783c-d082-4805-90ce-b2d32147aedb"), "Six", "Sixth" },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7096"), new Guid("8523783c-d082-4805-90ce-b2d32147aedb"), "Seven", "Seventh" },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7097"), new Guid("8523783c-d082-4805-90ce-b2d32147aedb"), "Eight", "8th" },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7098"), new Guid("ce82a987-8381-43c1-9dae-c1181da0510f"), "Nine", "Ninth" },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7099"), new Guid("ce82a987-8381-43c1-9dae-c1181da0510f"), "Ten", "Tenth" },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7100"), new Guid("ce82a987-8381-43c1-9dae-c1181da0510f"), "Eleven", "Eleventh" },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7102"), new Guid("ce82a987-8381-43c1-9dae-c1181da0510f"), "Twelve", "Twelfth" }
                });

            migrationBuilder.InsertData(
                table: "FridgeToProduct",
                columns: new[] { "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"), new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf51"), 10 },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"), new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf52"), 2 },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"), new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf53"), 2 },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"), new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf54"), 2 },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"), new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf55"), 2 },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"), new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf56"), 2 },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"), new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf57"), 2 },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7090"), new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf58"), 2 },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"), new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf51"), 10 },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"), new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf56"), 2 },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"), new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf57"), 2 },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"), new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf58"), 2 },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"), new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf59"), 2 },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"), new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf60"), 2 },
                    { new Guid("7b104622-4fef-465a-a5d4-2015de2c7091"), new Guid("43bf4f29-ec38-47a7-a2c2-80df6997bf61"), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_FridgeModelId",
                table: "Fridges",
                column: "FridgeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeToProduct_ProductId",
                table: "FridgeToProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "FridgeToProduct");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Fridges");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "FridgeModels");
        }
    }
}
