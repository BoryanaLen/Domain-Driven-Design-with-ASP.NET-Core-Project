namespace Hotel.Infrastructure.Administration
{
    using Common.Persistence;
    using Domain.Administration.Models.SpecialOffer;
    using Microsoft.EntityFrameworkCore;

    public interface IAdministrationDbContext : IDbContext
    {
        DbSet<SpecialOffer> SpecialOffers { get; }
    }
}
