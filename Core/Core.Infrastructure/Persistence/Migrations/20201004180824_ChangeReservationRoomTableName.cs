using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Infrastructure.Persistence.Migrations
{
    public partial class ChangeReservationRoomTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservationRooms_Reservations_ReservationId",
                table: "reservationRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_reservationRooms_Rooms_RoomId1",
                table: "reservationRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reservationRooms",
                table: "reservationRooms");

            migrationBuilder.RenameTable(
                name: "reservationRooms",
                newName: "ReservationRooms");

            migrationBuilder.RenameIndex(
                name: "IX_reservationRooms_RoomId1",
                table: "ReservationRooms",
                newName: "IX_ReservationRooms_RoomId1");

            migrationBuilder.RenameIndex(
                name: "IX_reservationRooms_ReservationId",
                table: "ReservationRooms",
                newName: "IX_ReservationRooms_ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationRooms",
                table: "ReservationRooms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationRooms_Reservations_ReservationId",
                table: "ReservationRooms",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationRooms_Rooms_RoomId1",
                table: "ReservationRooms",
                column: "RoomId1",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRooms_Reservations_ReservationId",
                table: "ReservationRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRooms_Rooms_RoomId1",
                table: "ReservationRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationRooms",
                table: "ReservationRooms");

            migrationBuilder.RenameTable(
                name: "ReservationRooms",
                newName: "reservationRooms");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationRooms_RoomId1",
                table: "reservationRooms",
                newName: "IX_reservationRooms_RoomId1");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationRooms_ReservationId",
                table: "reservationRooms",
                newName: "IX_reservationRooms_ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reservationRooms",
                table: "reservationRooms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_reservationRooms_Reservations_ReservationId",
                table: "reservationRooms",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservationRooms_Rooms_RoomId1",
                table: "reservationRooms",
                column: "RoomId1",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
