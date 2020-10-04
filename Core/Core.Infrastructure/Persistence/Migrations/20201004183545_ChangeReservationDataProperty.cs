using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Infrastructure.Persistence.Migrations
{
    public partial class ChangeReservationDataProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PricePerDay",
                table: "Reservations",
                newName: "TotalAmount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Reservations",
                newName: "PricePerDay");
        }
    }
}
