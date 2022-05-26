using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ecomerce.Migrations
{
    public partial class checkoutInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Discount_Tbl_Product_TblProductProductId",
            //    table: "Discount");

            //migrationBuilder.DropIndex(
            //    name: "IX_Discount_TblProductProductId",
            //    table: "Discount");

            //migrationBuilder.DropColumn(
            //    name: "TblProductProductId",
            //    table: "Discount");

            //migrationBuilder.AlterColumn<int>(
            //    name: "DiscountId",
            //    table: "Tbl_Product",
            //    type: "int",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            migrationBuilder.CreateTable(
                name: "CheckoutInfo",
                columns: table => new
                {
                    checkoutInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    //userId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<long>(type: "bigint", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    district = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    governorate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    specialMarque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    propertyNumber = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutInfo", x => x.checkoutInfoId);
                    table.ForeignKey(
                        name: "FK_CheckoutInfo_AspNetUsers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "payment_details",
                columns: table => new
                {
                    paymentDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<int>(type: "int", nullable: false),
                    provider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_details", x => x.paymentDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "Order_details",
                columns: table => new
                {
                    orderDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    checkoutInfoId = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentspaymentDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_details", x => x.orderDetailsId);
                    table.ForeignKey(
                        name: "FK_Order_details_CheckoutInfo_checkoutInfoId",
                        column: x => x.checkoutInfoId,
                        principalTable: "CheckoutInfo",
                        principalColumn: "checkoutInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_details_payment_details_PaymentspaymentDetailsId",
                        column: x => x.PaymentspaymentDetailsId,
                        principalTable: "payment_details",
                        principalColumn: "paymentDetailsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order_items",
                columns: table => new
                {
                    orderItemsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderDetailsId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TblProductProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_items", x => x.orderItemsId);
                    table.ForeignKey(
                        name: "FK_Order_items_Order_details_orderDetailsId",
                        column: x => x.orderDetailsId,
                        principalTable: "Order_details",
                        principalColumn: "orderDetailsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_items_Tbl_Product_TblProductProductId",
                        column: x => x.TblProductProductId,
                        principalTable: "Tbl_Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Tbl_Product_DiscountId",
            //    table: "Tbl_Product",
            //    column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutInfo_MemberId",
                table: "CheckoutInfo",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_details_checkoutInfoId",
                table: "Order_details",
                column: "checkoutInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_details_PaymentspaymentDetailsId",
                table: "Order_details",
                column: "PaymentspaymentDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_items_orderDetailsId",
                table: "Order_items",
                column: "orderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_items_TblProductProductId",
                table: "Order_items",
                column: "TblProductProductId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Tbl_Product_Discount",
            //    table: "Tbl_Product",
            //    column: "DiscountId",
            //    principalTable: "Discount",
            //    principalColumn: "DiscountId",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Product_Discount",
                table: "Tbl_Product");

            migrationBuilder.DropTable(
                name: "Order_items");

            migrationBuilder.DropTable(
                name: "Order_details");

            migrationBuilder.DropTable(
                name: "CheckoutInfo");

            migrationBuilder.DropTable(
                name: "payment_details");

            //migrationBuilder.DropIndex(
            //    name: "IX_Tbl_Product_DiscountId",
            //    table: "Tbl_Product");

            //migrationBuilder.AlterColumn<int>(
            //    name: "DiscountId",
            //    table: "Tbl_Product",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "TblProductProductId",
            //    table: "Discount",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Discount_TblProductProductId",
            //    table: "Discount",
            //    column: "TblProductProductId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Discount_Tbl_Product_TblProductProductId",
            //    table: "Discount",
            //    column: "TblProductProductId",
            //    principalTable: "Tbl_Product",
            //    principalColumn: "ProductId",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
