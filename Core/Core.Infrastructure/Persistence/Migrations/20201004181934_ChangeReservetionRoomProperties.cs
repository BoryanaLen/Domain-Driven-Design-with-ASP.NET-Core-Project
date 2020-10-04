using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Infrastructure.Persistence.Migrations
{
    public partial class ChangeReservetionRoomProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRooms_Reservations_ReservationId",
                table: "ReservationRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRooms_Rooms_RoomId1",
                table: "ReservationRooms");

            migrationBuilder.DropIndex(
                name: "IX_ReservationRooms_ReservationId",
                table: "ReservationRooms");

            migrationBuilder.DropIndex(
                name: "IX_ReservationRooms_RoomId1",
                table: "ReservationRooms");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "ReservationRooms");

            migrationBuilder.DropColumn(
                name: "RoomId1",
                table: "ReservationRooms");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "ReservationRooms",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationDataId",
                table: "ReservationRooms",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "RoomId",
                table: "ReservationRooms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ReservationDataId",
                table: "ReservationRooms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "ReservationRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId1",
                table: "ReservationRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRooms_ReservationId",
                table: "ReservationRooms",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRooms_RoomId1",
                table: "ReservationRooms",
                column: "RoomId1");

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
    }
}
