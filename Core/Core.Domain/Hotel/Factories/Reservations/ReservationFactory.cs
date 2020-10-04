namespace Core.Domain.Hotel.Factories.Reservations
{
    using Exceptions;
    using Models.Customers;
    using Models.Reservations;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReservationFactory : IReservationFactory
    {
        private Customer customer = default!;
        private DateTime startDate = default!;
        private DateTime endDate = default!;
        private int adults = default!;
        private int kids = default!;
        private decimal pricePerDay = default!;
        private decimal advancedPayment = default!;
        private ICollection<Room> rooms = default!;

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

        public IReservationFactory WithCustomer(Customer customer)
        {
            this.customer = customer;
            this.customerSet = true;
            return this;
        }

        public IReservationFactory WithCustomer(string firstName, string lastName, string email, string userId)
        {
            this.customer = new Customer(firstName, lastName, email, userId);
            this.customerSet = true;
            return this;
        }

        public IReservationFactory WithRooms(ICollection<Room> rooms)
        {
            this.rooms = rooms;
            return this;
        }

        public Reservation Build()
        {
            if (!this.customerSet)
            {
                throw new InvalidReservationException("Customer must have a value.");
            }

            return new Reservation(
                this.startDate,
                this.endDate,
                this.adults,
                this.kids,
                this.customer,
                this.pricePerDay,
                this.advancedPayment,
                this.isPaid,
                this.rooms.ToList()
                );
        }
    }
}
