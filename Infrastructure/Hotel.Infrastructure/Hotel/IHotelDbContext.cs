namespace Hotel.Infrastructure.Hotel
{
    using Common.Persistence;
    using Domain.Hotel.Models.Reservations;
    using Domain.Hotel.Models.Rooms;
    using Domain.Administration.Models.SpecialOffer;
    using Microsoft.EntityFrameworkCore;

    public interface IHotelDbContext : IDbContext
    {
        DbSet<Reservation> Reservations { get; }

        DbSet<Room> Rooms { get; }

        DbSet<Payment> Payments { get; }

        DbSet<RoomType> RoomTypes { get; }

        DbSet<PaymentType> PaymentTypes { get; }
    }
}
