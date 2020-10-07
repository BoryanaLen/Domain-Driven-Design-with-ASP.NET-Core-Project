namespace Core.Application.Hotel.SpecialOffers
{
    using Common.Application.Contracts;
    using Core.Application.Hotel.SpecialOffers.Queries.All;
    using Core.Domain.Hotel.Models.SpecialOffers;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISpecialOfferQueryRepository : IQueryRepository<SpecialOffer>
    {
        Task<IEnumerable<AllSpecialOfferOutputModel>> GetAllSpecialOffersList(
            int skip = 0,
            int take = int.MaxValue);

        Task<AllSpecialOffersOutputModel> GetOffers();

    }
}
