namespace Core.Infrastructure.Hotel.Repositories.SpecialOffer
{
    using System.Collections.Generic;
    using System.Threading;
    using Core.Application.Hotel.SpecialOffers.Queries.All;
    using Core.Infrastructure.Persistence.Models.SpecialOfferData;
    using global::Common.Application.Contracts;

    public interface ISpecialOfferQueryRepository : IQueryRepository<SpecialOfferData>
    {
        IEnumerable<AllSpecialOfferOutputModel> GetAllSpecialOffersList(
             CancellationToken cancellationToken = default,
                 int skip = 0,
                 int take = int.MaxValue);

    }
}
