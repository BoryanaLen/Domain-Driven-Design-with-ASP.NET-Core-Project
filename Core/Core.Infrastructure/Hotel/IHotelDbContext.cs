namespace Core.Infrastructure.Hotel
{
    using Core.Domain.Hotel.Models.Customers;
    using Core.Domain.Hotel.Models.Reservations;
    using Core.Infrastructure.Persistence;
    using Microsoft.EntityFrameworkCore;

    internal interface IHotelDbContext : IDbContext
    {
        DbSet<Reservation> Reservations { get; }

        public DbSet<Room> Rooms { get; }

        public DbSet<RoomType> RoomTypes { get; }

        public DbSet<Customer> Customers { get; }
    }
}
