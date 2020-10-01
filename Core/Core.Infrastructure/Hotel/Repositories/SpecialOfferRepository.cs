namespace Core.Infrastructure.Hotel.Repositories
{
    using Core.Application.Hotel.SpecialOffers.Queries;
    using Core.Application.Hotel.SpecialOffers.Queries.All;
    using Core.Domain.Hotel.Models.SpecialOffers;
    using Core.Domain.Hotel.Repositories;
    using Core.Infrastructure.Persistence;
    using Core.Infrastructure.Persistence.Models.SpecialOfferData;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SpecialOfferRepository : DataRepository<HotelSystemDbContext, SpecialOfferData>,
        ISpecialOfferDomainRepository,
        ISpecialOfferQueryRepository
    {
        public SpecialOfferRepository(HotelSystemDbContext db)
            : base(db)
        {

        }

        public IEnumerable<AllSpecialOfferOutputModel> GetAllSpecialOffersList(
            CancellationToken cancellationToken = default,
            int skip = 0,
            int take = int.MaxValue)
        {
            List<SpecialOfferData> list = this.Data
            .SpecialOffers
            .ToList();

            var result = list
            .Select(x => new AllSpecialOfferOutputModel()
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                ShortContent = x.ShortContent
            }).ToList();

            return result;
        }

        public Task Save(HotelSpecialOffer entity, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
