namespace Core.Infrastructure.Persistence.Factories.ReservationData
{
    using Models;
    using Models.PaymentTypeData;
    using Models.ReservationData;
    using Exceptions;
    using System;

    internal class ReservationDataFactory : IReservationDataFactory
    {
        private CustomerData customer = default!;
        private PaymentTypeData paymentType = default!;
        private DateTime startDate = default!;
        private DateTime endDate = default!;
        private int adults = default!;
        private int kids = default!;
        private decimal pricePerDay = default!;
        private decimal advancedPayment = default!;

        private bool isPaid = false;
        private bool customerSet = false;


        public IReservationDataFactory WithAdults(int adults)
        {
            this.adults = adults;
            return this;
        }

        public IReservationDataFactory WithAdvancedPayment(decimal advancedPayment)
        {
            this.advancedPayment = advancedPayment;
            return this;
        }

        public IReservationDataFactory WithCustomer(CustomerData customer)
        {
            this.customer = customer;
            this.customerSet = true;
            return this;
        }

        public IReservationDataFactory WithEndDate(DateTime endDate)
        {
            this.endDate = endDate;
            return this;
        }

        public IReservationDataFactory WithIsPaid(bool isPaid)
        {
            this.isPaid = isPaid;
            return this;
        }

        public IReservationDataFactory WithKids(int kids)
        {
            this.kids = kids;
            return this;
        }

        public IReservationDataFactory WithPaymentType(PaymentTypeData paymentType)
        {
            this.paymentType = paymentType;
            return this;
        }

        public IReservationDataFactory WithPricePerDay(decimal pricePerDay)
        {
            this.pricePerDay = pricePerDay;
            return this;
        }

        public IReservationDataFactory WithStartDate(DateTime startDate)
        {
            this.startDate = startDate;
            return this;
        }

        public ReservationData Build()
        {
            if (!this.customerSet)
            {
                throw new InvalidReservationDataException("Customer must have a value.");
            }

            return new ReservationData(
                this.startDate,
                this.endDate,
                this.adults,
                this.kids,
                this.customer,
                this.pricePerDay,
                this.advancedPayment,
                this.isPaid
                );
        }
    }
}
