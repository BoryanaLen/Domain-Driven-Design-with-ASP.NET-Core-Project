namespace Core.Infrastructure.Administration
{
    using Core.Domain.Administration.Models.Payments;
    using Persistence;
    using Persistence.Models;
    using Microsoft.EntityFrameworkCore;

    internal interface IAdministrationDbContext : IDbContext
    {
         DbSet<SpecialOfferData> SpecialOffers { get; }

         DbSet<PaymentData> Payments { get; }

         DbSet<PaymentType> PaymentTypes { get; }
    }
}
