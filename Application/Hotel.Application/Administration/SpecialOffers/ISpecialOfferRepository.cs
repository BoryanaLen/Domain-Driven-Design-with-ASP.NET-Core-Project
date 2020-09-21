namespace Hotel.Application.Administration.SpecialOffers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Contracts;
    using Domain.Administration.Models.SpecialOffer;

    public interface ISpecialOfferRepository : IRepository<SpecialOffer>
    {
        Task GetAllSpecialOffers(CancellationToken cancellationToken = default);
    }
}
