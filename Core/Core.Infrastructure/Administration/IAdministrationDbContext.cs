namespace Core.Infrastructure.Administration
{
    using Core.Domain.Administration.Models.Payments;
    using Core.Domain.Administration.Models.SpecialOffers;
    using Core.Infrastructure.Persistence;
    using Microsoft.EntityFrameworkCore;

    internal interface IAdministrationDbContext : IDbContext
    {
         DbSet<SpecialOffer> SpecialOffers { get; }

        DbSet<Payment> Payments { get; }

        DbSet<PaymentType> PaymentTypes { get; }
    }
}
