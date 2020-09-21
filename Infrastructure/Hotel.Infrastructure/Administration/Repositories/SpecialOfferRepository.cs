namespace Hotel.Infrastructure.Administration.Repositories
{
    using AutoMapper;
    using Hotel.Application.Administration.SpecialOffers;
    using Hotel.Domain.Administration.Models.SpecialOffer;
    using Hotel.Infrastructure.Common.Persistence;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SpecialOfferRepository : DataRepository<IAdministrationDbContext, SpecialOffer>, ISpecialOfferRepository
    {
        private readonly IMapper mapper;

        public SpecialOfferRepository(IAdministrationDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<SpecialOffer> Find(int id, CancellationToken cancellationToken = default)
            => await this
                .All()
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var specialOffer = await this.Data.SpecialOffers.FindAsync(id);

            if (specialOffer == null)
            {
                return false;
            }

            this.Data.SpecialOffers.Remove(specialOffer);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IEnumerable<TOutputModel>> GetCarAdListings<TOutputModel>(
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => (await this.mapper
                .ProjectTo<TOutputModel>
                .ToListAsync(cancellationToken))
                .Skip(skip)
                .Take(take); // EF Core bug forces me to execute paging on the client.


        private IQueryable<SpecialOffer> AllSpecialOffers()
            => this
                .All();

        public async Task GetAllSpecialOffers(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
