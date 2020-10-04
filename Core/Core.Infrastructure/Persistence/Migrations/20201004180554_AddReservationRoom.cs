using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Infrastructure.Persistence.Migrations
{
    public partial class AddReservationRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reservationRooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationDataId = table.Column<string>(nullable: false),
                    ReservationId = table.Column<int>(nullable: false),
                    RoomId = table.Column<string>(nullable: false),
                    RoomId1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservationRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reservationRooms_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservationRooms_Rooms_RoomId1",
                        column: x => x.RoomId1,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reservationRooms_ReservationId",
                table: "reservationRooms",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_reservationRooms_RoomId1",
                table: "reservationRooms",
                column: "RoomId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservationRooms");
        }
    }
}
