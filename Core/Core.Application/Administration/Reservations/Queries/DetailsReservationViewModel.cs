namespace Core.Application.Administration.Reservations.Queries
{
    using System;

    public class DetailsReservationViewModel
    {
        public string Id { get; set; } = default!;

        public decimal TotalAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
