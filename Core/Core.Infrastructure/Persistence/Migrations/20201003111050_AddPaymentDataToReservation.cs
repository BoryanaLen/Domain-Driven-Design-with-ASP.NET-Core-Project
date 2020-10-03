using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Infrastructure.Persistence.Migrations
{
    public partial class AddPaymentDataToReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.AddColumn<int>(
                name: "ReservationDataId",
                table: "Payments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ReservationDataId",
                table: "Payments",
                column: "ReservationDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Reservations_ReservationDataId",
                table: "Payments",
                column: "ReservationDataId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Reservations_ReservationDataId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ReservationDataId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ReservationDataId",
                table: "Payments");

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfPayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Reservations_ReservationDataId",
                        column: x => x.ReservationDataId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ReservationDataId",
                table: "Payment",
                column: "ReservationDataId");
        }
    }
}
