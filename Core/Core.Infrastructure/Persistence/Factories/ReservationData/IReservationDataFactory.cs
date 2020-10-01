namespace Core.Infrastructure.Persistence.Factories.ReservationData
{
    using Common.Domain;
    using Models.ReservationData;
    using Models.PaymentTypeData;
    using System;
    using Models;

    public interface IReservationDataFactory : IFactory<ReservationData>
    {
        IReservationDataFactory WithStartDate(DateTime startDate);

        IReservationDataFactory WithEndDate(DateTime endDate);

        IReservationDataFactory WithAdults(int adults);

        IReservationDataFactory WithKids(int kids);

        IReservationDataFactory WithPricePerDay(decimal pricePerDay);

        IReservationDataFactory WithAdvancedPayment(decimal advancedPayment);

        IReservationDataFactory WithIsPaid(bool isPaid);

        IReservationDataFactory WithCustomer(CustomerData customer);

        IReservationDataFactory WithPaymentType(PaymentTypeData paymentType);
    }
}
