namespace Application.Hotel.SpecialOffers
{
    using Application.Hotel.SpecialOffers.Queries.All;
    using System.Collections.Generic;
    using System.Threading;

    public interface ISpecialOfferRepository
    {
        IEnumerable<AllSpecialOfferOutputModel> GetAllSpecialOffersList(
             CancellationToken cancellationToken = default,
                 int skip = 0,
                 int take = int.MaxValue);

    }
}
