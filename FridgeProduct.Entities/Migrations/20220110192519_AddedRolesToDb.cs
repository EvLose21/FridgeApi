using Microsoft.EntityFrameworkCore.Migrations;

namespace FridgeProduct.Entities.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37710fb0-bcb9-45b2-86ff-9992f91fd611", "dfacfcf3-f49e-411a-8b8b-29d139b233d0", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "38fc5ac8-6339-4cbf-8269-06a7d408aa96", "f29488a7-4c7f-4d9e-bc49-647ff3d4f573", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37710fb0-bcb9-45b2-86ff-9992f91fd611");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38fc5ac8-6339-4cbf-8269-06a7d408aa96");
        }
    }
}
