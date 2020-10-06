namespace Core.Infrastructure.Administration
{
    using Core.Domain.Administration.Models.Payments;
    using Persistence;
    using Persistence.Models;
    using Microsoft.EntityFrameworkCore;
    using Core.Domain.Hotel.Models.Reservations;

    internal interface IAdministrationDbContext : IDbContext
    {
         DbSet<SpecialOfferData> SpecialOffers { get; }

         DbSet<PaymentData> Payments { get; }

         DbSet<PaymentType> PaymentTypes { get; }

        DbSet<ReservationRoomData> ReservationRooms { get; }

        DbSet<ReservationData> Reservations { get; }

        DbSet<RoomData> Rooms { get; }
    }
}
