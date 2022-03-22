using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ecomerce.Migrations
{
    public partial class NewSeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "Vendor", "Vendor".ToUpper(), Guid.NewGuid().ToString() }
                //schema: "security"
            );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "IOTUser", "IOTUser".ToUpper(), Guid.NewGuid().ToString() }
                //schema: "security"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
