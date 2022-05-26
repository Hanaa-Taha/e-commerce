using Microsoft.EntityFrameworkCore.Migrations;

namespace ecomerce.Migrations
{
    public partial class discount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "discountId",
                table: "Tbl_Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    discountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discountPercent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.discountId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Product_discountId",
                table: "Tbl_Product",
                column: "discountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Product_Discount_discountId",
                table: "Tbl_Product",
                column: "discountId",
                principalTable: "Discount",
                principalColumn: "discountId",
                onDelete: ReferentialAction.Cascade);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

        }
    }
}
