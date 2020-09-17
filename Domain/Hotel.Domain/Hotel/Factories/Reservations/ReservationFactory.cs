using Hotel.Domain.Hotel.Exceptions;
using Hotel.Domain.Hotel.Models.Reservations;
using System;

namespace Hotel.Domain.Hotel.Factories.Reservations
{
    internal class ReservationFactory : IReservationFactory
    {
        private Customer customer = default!;
        private PaymentType paymentType = default!;
        private DateTime startDate = default!;
        private DateTime endDate = default!;
        private int adults = default!;
        private int kids = default!;
        private decimal pricePerDay = default!;
        private decimal advancedPayment = default!;

        private bool isPaid = false;
        private bool customerSet = false;


        public IReservationFactory WithAdults(int adults)
        {
            this.adults = adults;
            return this;
        }

        public IReservationFactory WithAdvancedPayment(decimal advancedPayment)
        {
            this.advancedPayment = advancedPayment;
            return this;
        }

        public IReservationFactory WithCustomer(string firstName, string lastName, string email)
           => this.WithCustomer(new Customer(firstName, lastName, email));

        public IReservationFactory WithCustomer(Customer customer)
        {
            this.customer = customer;
            this.customerSet = true;
            return this;
        }

        public IReservationFactory WithEndDate(DateTime endDate)
        {
            this.endDate = endDate;
            return this;
        }

        public IReservationFactory WithIsPaid(bool isPaid)
        {
            this.isPaid = isPaid;
            return this;
        }

        public IReservationFactory WithKids(int kids)
        {
            this.kids = kids;
            return this;
        }

        public IReservationFactory WithPaymentType(PaymentType paymentType)
        {
            this.paymentType = paymentType;
            return this;
        }

        public IReservationFactory WithPricePerDay(decimal pricePerDay)
        {
            this.pricePerDay = pricePerDay;
            return this;
        }

        public IReservationFactory WithStartDate(DateTime startDate)
        {
            this.startDate = startDate;
            return this;
        }

        public Reservation Build()
        {
            if (!this.customerSet )
            {
                throw new InvalidReservationException("Customer must have a value.");
            }

            return new Reservation(
                this.startDate,
                this.endDate,
                this.adults,
                this.kids,
                this.customer,
                this.paymentType,
                this.pricePerDay,
                this.advancedPayment,
                this.isPaid
                );
        }
    }
}
