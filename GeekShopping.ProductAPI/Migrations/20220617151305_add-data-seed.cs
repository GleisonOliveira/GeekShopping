using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.ProductAPI.Migrations
{
    public partial class adddataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "name" },
                values: new object[] { 1L, "Roupas" });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "CategoryId", "description", "image_url", "name", "price" },
                values: new object[] { 1L, 1L, "Camiseta", "url", "Camiseta", 5m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 1L);
        }
    }
}
