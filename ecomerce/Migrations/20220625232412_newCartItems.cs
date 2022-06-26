using Microsoft.EntityFrameworkCore.Migrations;

namespace ecomerce.Migrations
{
    public partial class newCartItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Tbl_Product_TblProductProductId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Cart_Tbl_Members",
                table: "Tbl_Cart");

            

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Cart_MemberId",
                table: "Tbl_Cart");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_tblCartId",
                table: "CartItems");

            

            

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "Tbl_Cart",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "CartItems",
                type: "nvarchar(450)",
                nullable: true);

            

            

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_tblCartId",
                table: "CartItems",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Tbl_Cart",
                table: "CartItems",
                column: "userId",
                principalTable: "Tbl_Cart",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Tbl_Product_TblProductProductId",
                table: "CartItems",
                column: "TblProductProductId",
                principalTable: "Tbl_Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Cart_Tbl_Members",
                table: "Tbl_Cart",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Tbl_Cart",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Tbl_Product_TblProductProductId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Cart_Tbl_Members",
                table: "Tbl_Cart");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Tbl_Cart__51BCD7B7F7E8BC66",
                table: "Tbl_Cart");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_tblCartId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "CartItems");

            

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "Tbl_Cart",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Tbl_Cart",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            

            migrationBuilder.AddPrimaryKey(
                name: "PK__Tbl_Cart__51BCD7B7F7E8BC66",
                table: "Tbl_Cart",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Cart_MemberId",
                table: "Tbl_Cart",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_tblCartId",
                table: "CartItems",
                column: "tblCartId");

            

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Tbl_Product_TblProductProductId",
                table: "CartItems",
                column: "TblProductProductId",
                principalTable: "Tbl_Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Cart_Tbl_Members",
                table: "Tbl_Cart",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
