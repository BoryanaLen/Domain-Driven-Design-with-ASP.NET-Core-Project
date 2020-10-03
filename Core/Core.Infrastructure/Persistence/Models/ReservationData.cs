namespace Core.Infrastructure.Persistence.Models.ReservationData
{
    using System;
    using System.Collections.Generic;
    using Common.Application.Mapping;
    using Core.Domain.Hotel.Models.Customers;
    using Core.Domain.Hotel.Models.Reservations;

    internal class ReservationData : IMapTo<Reservation>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Adults { get; set; }

        public int Kids { get; set; }

        public Customer Customer { get; set; } = default!;

        public decimal PricePerDay { get; set; }

        public decimal AdvancedPayment { get; set; }        

        public bool IsPaid { get; set; }

        public ICollection<Room> Rooms { get; } = new List<Room>();

        public ICollection<Payment> Payments { get; } = new List<Payment>();
    }
}
