namespace Core.Infrastructure.Persistence.Models
{
    using Common.Domain.Models;

    internal class ReservationRoomData : Entity<int>
    {
        public ReservationRoomData(int reservationDataId, int roomId)
        {
            this.ReservationDataId = reservationDataId;
            this.RoomId = roomId;
        }
        public int ReservationDataId { get; set; } = default!;

        public int RoomId { get; set; } = default!;
    }
}
