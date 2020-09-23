namespace Domain.Hotel.Factories.Reservations
{
    using Common;
    using Models.Customers;
    using Models.Reservations;
    using System;

    public interface IReservationFactory:  IFactory<Reservation>
    {
        IReservationFactory WithStartDate(DateTime startDate);

        IReservationFactory WithEndDate(DateTime endDate);

        IReservationFactory WithAdults(int adults);

        IReservationFactory WithKids(int kids);

        IReservationFactory WithPricePerDay(decimal pricePerDay);

        IReservationFactory WithAdvancedPayment(decimal advancedPayment);

        IReservationFactory WithIsPaid(bool isPaid);

        IReservationFactory WithCustomer(Customer customer);

        IReservationFactory WithPaymentType(PaymentType paymentType);
    }
}
