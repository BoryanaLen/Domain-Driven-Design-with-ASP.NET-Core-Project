namespace Core.Infrastructure.Persistence.Factories.ReservationData
{
    using Common.Domain;
    using Models.CustomerData;
    using Models.RoomData;
    using Models.ReservationData;
    using System;
    using System.Collections.Generic;

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

        IReservationDataFactory WithRooms(List<RoomData> rooms);
    }
}
