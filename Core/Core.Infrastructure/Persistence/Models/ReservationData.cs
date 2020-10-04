namespace Core.Infrastructure.Persistence.Models
{
    using System;
    using System.Collections.Generic;
    using Common.Domain;
    using Common.Domain.Models;
    using Core.Domain.Hotel.Models.Customers;
    using Core.Domain.Hotel.Models.Reservations;

    public class ReservationData : Entity<int>, IAggregateRoot
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

        public ICollection<PaymentData> Payments { get; } = new List<PaymentData>();
    }
}
