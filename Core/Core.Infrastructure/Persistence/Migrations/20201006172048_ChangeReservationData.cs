using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Infrastructure.Persistence.Migrations
{
    public partial class ChangeReservationData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRooms_Reservations_ReservationDataId",
                table: "ReservationRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRooms_Rooms_RoomId",
                table: "ReservationRooms");

            migrationBuilder.DropIndex(
                name: "IX_ReservationRooms_ReservationDataId",
                table: "ReservationRooms");

            migrationBuilder.DropIndex(
                name: "IX_ReservationRooms_RoomId",
                table: "ReservationRooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ReservationRooms_ReservationDataId",
                table: "ReservationRooms",
                column: "ReservationDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRooms_RoomId",
                table: "ReservationRooms",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationRooms_Reservations_ReservationDataId",
                table: "ReservationRooms",
                column: "ReservationDataId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationRooms_Rooms_RoomId",
                table: "ReservationRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
