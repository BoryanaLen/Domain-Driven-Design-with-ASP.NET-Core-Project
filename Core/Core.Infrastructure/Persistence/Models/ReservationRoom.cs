namespace Core.Infrastructure.Persistence.Models
{
    using Common.Domain.Models;
    using Core.Domain.Hotel.Models.Reservations;

    internal class ReservationRoom : Entity<int>
    {
        public ReservationRoom(int reservationDataId, int roomId)
        {
            this.ReservationDataId = reservationDataId;
            this.RoomId = roomId;
        }

        public int ReservationDataId { get; set; } =  default!;

        public virtual ReservationData Reservation { get; set; } = default!;

        public int RoomId { get; set; } = default!;

        public virtual Room Room { get; set; } = default!;
    }
}
