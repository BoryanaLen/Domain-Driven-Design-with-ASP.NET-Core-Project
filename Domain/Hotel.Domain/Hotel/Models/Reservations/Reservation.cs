namespace Hotel.Domain.Hotel.Models.Reservations
{
    using Common;
    using Room;

    using System;
    using System.Collections.Generic;

    public class Reservation : Entity<int>, IAggregateRoot
    {
        internal Reservation(
            DateTime startDate,
            DateTime endDate,
            int adults,
            int kids,
            HotelUser user,
            PaymentType paymentType,
            decimal pricePerDay,
            decimal advancedPayment,
            bool isPaid
            )
        {
            this.Validate(startDate, endDate, adults, kids, pricePerDay, advancedPayment, pricePerDay);
            this.ValidatePaymentType(paymentType);

            this.User = user;
            this.PaymentType = paymentType;

            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Adults = adults;
            this.Kids = kids;
            this.PricePerDay = pricePerDay;
            this.AdvancedPayment = advancedPayment;
            this.IsPaid = isPaid;
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

            this.User = default!;
            this.PaymentType = default!;
        }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public int Adults { get; private set; }

        public int Kids { get; private set; }

        public HotelUser User { get; private set; }

        public PaymentType PaymentType { get; private set; }

        public decimal PricePerDay { get; private set; }

        public decimal AdvancedPayment { get; private set; }        

        public bool IsPaid { get; private set; }

        public ICollection<Room> ReservationRooms { get; } = new List<Room>();

        public ICollection<Payment> ReservationPayments { get; } = new List<Payment>();

        public int TotalDays => (int)(this.EndDate - this.StartDate).TotalDays;

        public decimal TotalAmount => this.TotalDays * this.PricePerDay;

        public decimal AmountForPayment => this.TotalAmount - this.AdvancedPayment;

        public Reservation UpdateUser(HotelUser user)
        {
            //this.ValidateUser(category);
            this.User = user;

            return this;
        }

        public Reservation UpdatePaymentType(PaymentType paymentType)
        {
            this.ValidatePaymentType(paymentType);
            this.PaymentType = paymentType;

            return this;
        }

        
        private void Validate(DateTime startDate, DateTime endDate, int adults, int kids, decimal pricePerDay, decimal advancedPayment, decimal pricePerDay)
        {
            this.ValidateModel(model);
            this.ValidateImageUrl(imageUrl);
            this.ValidatePricePerDay(pricePerDay);
        }

       

    }
}
