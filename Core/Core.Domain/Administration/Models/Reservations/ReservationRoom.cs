namespace Core.Domain.Administration.Models.Reservations
{
    using Common.Domain.Models;

    internal class ReservationRoom : Entity<int>
    {
        public int ReservationDataId { get; set; } = default!;

        public int RoomId { get; set; } = default!;
    }
}
