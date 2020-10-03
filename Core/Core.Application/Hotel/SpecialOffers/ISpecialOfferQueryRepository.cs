namespace Core.Application.Hotel.SpecialOffers
{
    using Common.Application.Contracts;
    using Core.Application.Hotel.SpecialOffers.Queries.All;
    using Core.Domain.Administration.Models.SpecialOffers;
    using System.Collections.Generic;
    using System.Threading;

    public interface ISpecialOfferQueryRepository : IQueryRepository<SpecialOffer>
    {
        IEnumerable<AllSpecialOfferOutputModel> GetAllSpecialOffersList(
             CancellationToken cancellationToken = default,
                 int skip = 0,
                 int take = int.MaxValue);

    }
}
