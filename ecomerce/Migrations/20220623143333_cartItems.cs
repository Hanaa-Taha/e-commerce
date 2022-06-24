using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ecomerce.Migrations
{
    public partial class cartItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Cart_Tbl_Product",
                table: "Tbl_Cart");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Cart_ProductId",
                table: "Tbl_Cart");

           

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Tbl_Cart");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Tbl_Cart");

            
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    cartItemsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tblCartId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TblProductProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.cartItemsId);
                    table.ForeignKey(
                        name: "FK_CartItems_Tbl_Cart_tblCartId",
                        column: x => x.tblCartId,
                        principalTable: "Tbl_Cart",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Tbl_Product_TblProductProductId",
                        column: x => x.TblProductProductId,
                        principalTable: "Tbl_Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_tblCartId",
                table: "CartItems",
                column: "tblCartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_TblProductProductId",
                table: "CartItems",
                column: "TblProductProductId");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "CartItems");

            

            

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Tbl_Cart",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Tbl_Cart",
                type: "int",
                nullable: true);

            
            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Cart_ProductId",
                table: "Tbl_Cart",
                column: "ProductId");

            

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Cart_Tbl_Product",
                table: "Tbl_Cart",
                column: "ProductId",
                principalTable: "Tbl_Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
