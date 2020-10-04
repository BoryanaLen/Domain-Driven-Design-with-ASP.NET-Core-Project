namespace Core.Domain.Hotel.Factories.Reservations
{
    using Common.Domain;
    using Models.Customers;
    using Models.Reservations;
    using System;
    using System.Collections.Generic;

    public interface IReservationFactory:  IFactory<Reservation>
    {
        IReservationFactory WithStartDate(DateTime startDate);

        IReservationFactory WithEndDate(DateTime endDate);

        IReservationFactory WithAdults(int adults);

        IReservationFactory WithKids(int kids);

        IReservationFactory WithTotalAmount(decimal pricePerDay);

        IReservationFactory WithAdvancedPayment(decimal advancedPayment);

        IReservationFactory WithIsPaid(bool isPaid);

        IReservationFactory WithCustomer(Customer customer);

        IReservationFactory WithRooms(ICollection<Room> rooms);

        IReservationFactory WithCustomer(string firstName, string lastName, string email, string userId);
    }
}
