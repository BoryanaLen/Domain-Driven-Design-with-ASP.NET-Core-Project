namespace Hotel.Infrastructure.Administration
{
    using Common.Persistence;
    using Domain.Administration.Models.SpecialOffer;
    using Identity;
    using Microsoft.EntityFrameworkCore;

    public interface IAdministrationDbContext : IDbContext
    {
        DbSet<SpecialOffer> SpecialOffers { get; }
    }
}
