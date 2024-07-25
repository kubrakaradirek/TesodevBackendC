using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesodevBackendC.Customer.WebApi.Migrations
{
    public partial class customerrıd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customerrs_CustomerId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Addresses",
                newName: "CustomerrId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                newName: "IX_Addresses_CustomerrId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Customerrs_CustomerrId",
                table: "Addresses",
                column: "CustomerrId",
                principalTable: "Customerrs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customerrs_CustomerrId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "CustomerrId",
                table: "Addresses",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CustomerrId",
                table: "Addresses",
                newName: "IX_Addresses_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Customerrs_CustomerId",
                table: "Addresses",
                column: "CustomerId",
                principalTable: "Customerrs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
