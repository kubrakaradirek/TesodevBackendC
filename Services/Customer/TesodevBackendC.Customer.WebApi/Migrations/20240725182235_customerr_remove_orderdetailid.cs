using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesodevBackendC.Customer.WebApi.Migrations
{
    public partial class customerr_remove_orderdetailid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "Customerrs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderDetailId",
                table: "Customerrs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
