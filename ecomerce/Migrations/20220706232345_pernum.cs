using Microsoft.EntityFrameworkCore.Migrations;

namespace ecomerce.Migrations
{
    public partial class pernum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Tbl_Cart_userId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_userId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "checkoutInfo");

            migrationBuilder.AlterColumn<string>(
                name: "propertyNumber",
                table: "checkoutInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "checkoutInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TblCartMemberId",
                table: "CartItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_TblCartMemberId",
                table: "CartItems",
                column: "TblCartMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Tbl_Cart_TblCartMemberId",
                table: "CartItems",
                column: "TblCartMemberId",
                principalTable: "Tbl_Cart",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Tbl_Cart_TblCartMemberId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_TblCartMemberId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "TblCartMemberId",
                table: "CartItems");

            migrationBuilder.AlterColumn<int>(
                name: "propertyNumber",
                table: "checkoutInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "phone",
                table: "checkoutInfo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "amount",
                table: "checkoutInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "CartItems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_userId",
                table: "CartItems",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Tbl_Cart_userId",
                table: "CartItems",
                column: "userId",
                principalTable: "Tbl_Cart",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
