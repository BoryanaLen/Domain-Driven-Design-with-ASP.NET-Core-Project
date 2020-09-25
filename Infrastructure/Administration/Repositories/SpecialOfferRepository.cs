namespace Infrastructure.Administration.Repositories
{
    using AutoMapper;
    using Domain.Administration.Models.SpecialOffer;
    using Infrastructure.Common.Persistence;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Administration.SpecialOffers.Queries.All;
    using Application.Administration.SpecialOffers;

    internal class SpecialOfferRepository : DataRepository<IAdministrationDbContext, SpecialOffer>, ISpecialOfferRepository
    {
        private readonly IMapper mapper;

        public SpecialOfferRepository(HotelDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<SpecialOffer> Find(int id, CancellationToken cancellationToken = default)
           => await this
               .All()
               .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var offer = await this.Data.SpecialOffers.FindAsync(id);

            if (offer == null)
            {
                return false;
            }

            this.Data.SpecialOffers.Remove(offer);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<int> Total(CancellationToken cancellationToken = default)
            => await this
                .GetSpecialOffersQuery()
                .CountAsync(cancellationToken);

        private IQueryable<SpecialOffer> GetSpecialOffersQuery()
            => this
                .Data
                .SpecialOffers;

        public IEnumerable<SpecialOffer> GetAll()
        {
            return this
                .Data.SpecialOffers.ToList();
        }

        public IEnumerable<AllSpecialOfferOutputModel> GetAllSpecialOffersList<AllSpecialOfferOutputModel>(
          CancellationToken cancellationToken = default,
          int skip = 0,
          int take = int.MaxValue)
        {
            var list = this.GetAll();

            //var result = (await this.mapper
            //  .ProjectTo<AllSpecialOfferOutputModel>(this
            //      .GetSpecialOffersQuery())
            //  .ToListAsync(cancellationToken))
            //  .Skip(skip)
            //  .Take(take);

            var result = this.mapper.Map<IList<AllSpecialOfferOutputModel>>(list);

            return result;
        }

        public async Task<AllSpecialOfferOutputModel> GetDetailsById(int offerId)
        {
            var offer = await this
                    .All()
                    .Where(d => d.Id == offerId)
                    .FirstOrDefaultAsync();

            var result = mapper.Map<AllSpecialOfferOutputModel>(offer);

            return result;
        }
 

        //public IQueryable<T> GetAllSpecialOffers<T>()
        //{
        //    IQueryable<SpecialOffer> query =
        //        this
        //        .All()
        //        .OrderByDescending(x => x.Id);

        //    return query.To<T>();
        //}

    }
}
