namespace Application.Hotel.Reservations.Queries.HomePage
{
    using System;

    public class CheckAvailableRoomsViewOutputModel
    {
        public DateTime CheckIn { get; set; } = default!;

        public DateTime CheckOut { get; set; } = default!;

        public int Adults { get; set; }

        public int Kids { get; set; }
    }
}
