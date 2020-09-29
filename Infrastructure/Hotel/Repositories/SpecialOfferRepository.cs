namespace Infrastructure.Hotel.Repositories
{
    using Application.Hotel.SpecialOffers;
    using Application.Hotel.SpecialOffers.Queries.All;
    using Infrastructure.Common.Persistence;
    using Infrastructure.Common.Persistence.Models.SpecialOfferData;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    internal class SpecialOfferRepository : DataRepository<HotelDbContext,SpecialOfferData>, ISpecialOfferRepository
    {
        public SpecialOfferRepository(HotelDbContext db)
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
    }
}
