using Microsoft.EntityFrameworkCore.Migrations;

namespace ecomerce.Migrations
{
    public partial class addVendor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VendorId",
                table: "Tbl_Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Product_VendorId",
                table: "Tbl_Product",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Produ_Tbl_Members",
                table: "Tbl_Product",
                column: "VendorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Produ_Tbl_Members",
                table: "Tbl_Product");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Product_VendorId",
                table: "Tbl_Product");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Tbl_Product");
        }
    }
}
