using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesodevBackendC.Order.Persistence.Migrations
{
    public partial class customerrid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "OrderDetails",
                newName: "CustomerrId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerrId",
                table: "OrderDetails",
                newName: "CustomerId");
        }
    }
}
