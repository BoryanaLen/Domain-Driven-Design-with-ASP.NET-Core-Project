namespace Infrastructure.Common.Persistence.Models.ReservationData
{
    using Domain.Common.Models;
    using System;
    using System.Collections.Generic;
    using RoomData;
    using PaymentData;
    using Domain.Common;

    public class ReservationData : Entity<int>, IAggregateRoot
    {
        internal ReservationData(
            DateTime startDate,
            DateTime endDate,
            int adults,
            int kids,
            CustomerData customer,
            decimal pricePerDay,
            decimal advancedPayment,
            bool isPaid
            )
        {
            this.Customer = customer;

            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Adults = adults;
            this.Kids = kids;
            this.PricePerDay = pricePerDay;
            this.AdvancedPayment = advancedPayment;
            this.IsPaid = isPaid;

            this.Rooms = new HashSet<RoomData>();
            this.Payments = new HashSet<PaymentData>();
        }

        private ReservationData(
            DateTime startDate,
            DateTime endDate,
            int adults,
            int kids,
            decimal pricePerDay,
            decimal advancedPayment,
            bool isPaid)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Adults = adults;
            this.Kids = kids;
            this.PricePerDay = pricePerDay;
            this.AdvancedPayment = advancedPayment;
            this.IsPaid = isPaid;

            this.Customer = default!;

            this.Rooms = new HashSet<RoomData>();
            this.Payments = new HashSet<PaymentData>();
        }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public int Adults { get; private set; }

        public int Kids { get; private set; }

        public CustomerData Customer { get; private set; }

        public decimal PricePerDay { get; private set; }

        public decimal AdvancedPayment { get; private set; }        

        public bool IsPaid { get; private set; }

        public ICollection<RoomData> Rooms { get; } = new List<RoomData>();

        public ICollection<PaymentData> Payments { get; } = new List<PaymentData>();
    }
}
