namespace Domain.Hotel.Models.Reservations
{
    using Common;
    using Exceptions;
    using Rooms;
    using Customers;
    using Common.Models;

    using System;
    using System.Collections.Generic;

    using static ModelConstants.Reservation;
    using static ModelConstants.Common;
    

    public class Reservation : Entity<int>, IAggregateRoot
    {
        internal Reservation(
            DateTime startDate,
            DateTime endDate,
            int adults,
            int kids,
            Customer customer,
            PaymentType paymentType,
            decimal pricePerDay,
            decimal advancedPayment,
            bool isPaid
            )
        {
            this.Validate(startDate, endDate, adults, kids, pricePerDay, advancedPayment);

            this.Customer = customer;
            this.PaymentType = paymentType;

            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Adults = adults;
            this.Kids = kids;
            this.PricePerDay = pricePerDay;
            this.AdvancedPayment = advancedPayment;
            this.IsPaid = isPaid;

            this.Rooms = new HashSet<Room>();
            this.Payments = new HashSet<Payment>();
        }

        private Reservation(
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
            this.PaymentType = default!;

            this.Rooms = new HashSet<Room>();
            this.Payments = new HashSet<Payment>();
        }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public int Adults { get; private set; }

        public int Kids { get; private set; }

        public Customer Customer { get; private set; }

        public PaymentType PaymentType { get; private set; }

        public decimal PricePerDay { get; private set; }

        public decimal AdvancedPayment { get; private set; }        

        public bool IsPaid { get; private set; }

        public ICollection<Room> Rooms { get; } = new List<Room>();

        public ICollection<Payment> Payments { get; } = new List<Payment>();

        public int TotalDays => (int)(this.EndDate - this.StartDate).TotalDays;

        public decimal TotalAmount => this.TotalDays * this.PricePerDay;

        public decimal AmountForPayment => this.TotalAmount - this.AdvancedPayment;

        public Reservation UpdateCustomer(Customer customer)
        {
            this.Customer = customer;

            return this;
        }

        public Reservation UpdatePaymentType(PaymentType paymentType)
        {
            this.PaymentType = paymentType;

            return this;
        }

        
        private void Validate(DateTime startDate, DateTime endDate, int adults, int kids, decimal pricePerDay, decimal advancedPayment)
        {
            this.ValidateStartDateAndEndDate(startDate, endDate);
            this.ValidateAdults(adults);
            this.ValidateKids(kids);
            this.ValidatePricePerDay(pricePerDay);
            this.ValidateAdvancedPayment(advancedPayment);
        }

        private void ValidateStartDateAndEndDate(DateTime startDate, DateTime endDate)
            => Guard.AgainstOutOfRangeStartAndEndDates<InvalidReservationException>(
                startDate,
                endDate);

        private void ValidateAdults(int adulds)
           => Guard.AgainstOutOfRange<InvalidRoomException>(
               adulds,
               MinNumberOfAdults,
               MaxNumberOfAdults,
               nameof(this.Adults));

        private void ValidateKids(int kids)
          => Guard.AgainstOutOfRange<InvalidReservationException>(
              kids,
              MinNumberOfKids,
              MaxNumberOfKids,
              nameof(this.Kids));

        private void ValidatePricePerDay(decimal pricePerDay)
            => Guard.AgainstOutOfRange<InvalidReservationException>(
                pricePerDay,
                Zero,
                decimal.MaxValue,
                nameof(this.PricePerDay));

        private void ValidateAdvancedPayment(decimal advancedPayment)
           => Guard.AgainstOutOfRange<InvalidReservationException>(
               advancedPayment,
               Zero,
               this.TotalAmount,
               nameof(this.AdvancedPayment));

    }
}
