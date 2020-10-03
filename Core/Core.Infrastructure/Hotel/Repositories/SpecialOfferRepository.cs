namespace Core.Infrastructure.Hotel.Repositories
{
    using AutoMapper;
    using Core.Application.Hotel.SpecialOffers;
    using Core.Application.Hotel.SpecialOffers.Queries.All;
    using Core.Domain.Hotel.Models.SpecialOffers;
    using Core.Domain.Hotel.Repositories.Reservations;
    using Core.Infrastructure.Persistence;
    using Core.Infrastructure.Persistence.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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

        public async Task<IEnumerable<AllSpecialOfferOutputModel>> GetAllSpecialOffersList(
            int skip = 0,
            int take = int.MaxValue)
        {
            var query = (await this.Data.SpecialOffers
                .ToListAsync())
                .Skip(skip)
                .Take(take);

            var list = new List<AllSpecialOfferOutputModel>();

            var result =  mapper.Map(query, list);

            return result.ToList();
        }
    }
}
