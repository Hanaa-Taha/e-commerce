using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ecomerce.Migrations
{
    public partial class editImageProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ProductImage",
                table: "Tbl_Product",
                type: "varbinary(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductImage",
                table: "Tbl_Product",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldUnicode: false,
                oldNullable: true);
        }
    }
}
