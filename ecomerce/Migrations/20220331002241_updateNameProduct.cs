using Microsoft.EntityFrameworkCore.Migrations;

namespace ecomerce.Migrations
{
    public partial class updateNameProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ__Tbl_Prod__DD5A978A4FD147D8",
                table: "Tbl_Product");

            migrationBuilder.RenameColumn(
                name: "fristName",
                table: "AspNetUsers",
                newName: "firstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "AspNetUsers",
                newName: "fristName");

            migrationBuilder.CreateIndex(
                name: "Tbl_Prod__DD5A978A4FD147D8",
                table: "Tbl_Product",
                column: "ProductName",
                unique: false,
                filter: "[ProductName] IS NOT NULL");
        }
    }
}
