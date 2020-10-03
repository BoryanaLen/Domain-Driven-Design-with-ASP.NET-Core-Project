namespace Core.Infrastructure.Hotel.Repositories
{
    using AutoMapper;
    using Core.Application.Hotel.SpecialOffers;
    using Core.Application.Hotel.SpecialOffers.Queries.All;
    using Core.Domain.Hotel.Models.SpecialOffers;
    using Core.Domain.Hotel.Repositories.Reservations;
    using Core.Infrastructure.Persistence;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    internal class SpecialOfferRepository : DataRepository<IHotelDbContext, SpecialOffer>,
        ISpecialOfferDomainRepository,
        ISpecialOfferQueryRepository
    {
        private readonly IMapper mapper;
        public SpecialOfferRepository(HotelSystemDbContext db, IMapper mapper)
            : base(db)
        {
            this.mapper = mapper;
        }

        public IEnumerable<AllSpecialOfferOutputModel> GetAllSpecialOffersList(
            CancellationToken cancellationToken = default,
            int skip = 0,
            int take = int.MaxValue)
        {
            //List<SpecialOffer> list = this.Data
            //.SpecialOffers
            //.ToList();

            List<SpecialOffer> list = this.Data
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
