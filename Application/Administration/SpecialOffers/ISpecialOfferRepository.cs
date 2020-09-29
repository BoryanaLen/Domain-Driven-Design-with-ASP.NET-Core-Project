namespace Application.Administration.SpecialOffers
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Hotel.SpecialOffers.Queries.All;
    using Domain.Administration.Models.SpecialOffer;

    public interface ISpecialOfferRepository
    {
        IEnumerable<AllSpecialOfferOutputModel> GetAllSpecialOffersList<AllSpecialOfferOutputModel>(
            CancellationToken cancellationToken = default,
                int skip = 0,
                int take = int.MaxValue);


        Task<AllSpecialOfferOutputModel> GetDetailsById(int offerId);

    }
}
