namespace Application.Administration.SpecialOffers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Administration.SpecialOffers.Queries.All;
    using Common.Contracts;
    using Domain.Administration.Models.SpecialOffer;

    public interface ISpecialOfferRepository
    {
        IEnumerable<AllSpecialOfferOutputModel> GetAllSpecialOffersList<AllSpecialOfferOutputModel>(
            CancellationToken cancellationToken = default,
                int skip = 0,
                int take = int.MaxValue);

        //Task<CarAdDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<int> Total(CancellationToken cancellationToken = default);

        Task<SpecialOffer> Find(int id, CancellationToken cancellationToken = default);

        Task Save(SpecialOffer specialOffer, CancellationToken cancellationToken);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

        Task<AllSpecialOfferOutputModel> GetDetailsById(int offerId);

        //IQueryable<T> GetAllSpecialOffers<T>();

    }
}
