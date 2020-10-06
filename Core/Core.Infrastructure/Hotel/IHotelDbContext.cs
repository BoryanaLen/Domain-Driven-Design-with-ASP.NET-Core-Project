namespace Core.Infrastructure.Hotel
{
    using Core.Domain.Hotel.Models.Customers;
    using Core.Domain.Hotel.Models.Reservations;
    using Microsoft.EntityFrameworkCore;
    using Persistence;
    using Persistence.Models;

    internal interface IHotelDbContext : IDbContext
    {
        DbSet<SpecialOfferData> SpecialOffers { get; }

        DbSet<ReservationData> Reservations { get; }

        DbSet<PaymentData> Payments { get; }      

        DbSet<RoomData> Rooms { get; }

        DbSet<RoomType> RoomTypes { get; }

        DbSet<Customer> Customers { get; }

        DbSet<ReservationRoomData> ReservationRooms { get; }
    }
}
