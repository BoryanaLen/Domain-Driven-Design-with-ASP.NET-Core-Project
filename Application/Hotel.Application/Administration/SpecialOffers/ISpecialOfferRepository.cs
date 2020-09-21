namespace Hotel.Application.Administration.SpecialOffers
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Contracts;
    using Domain.Administration.Models.SpecialOffer;

    public interface ISpecialOfferRepository : IRepository<SpecialOffer>
    {
        Task<IEnumerable<TOutputModel>> GetAllSpecialOffers<TOutputModel>(
           int skip = 0,
           int take = int.MaxValue,
           CancellationToken cancellationToken = default);
    }
}
