namespace Infrastructure.Administration.Repositories
{
    using AutoMapper;
    using Application.Administration.SpecialOffers;
    using Domain.Administration.Models.SpecialOffer;
    using Infrastructure.Common.Persistence;
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

        public async Task<IEnumerable<TOutputModel>> GetAllSpecialOffers<TOutputModel>(
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => (await this.mapper
                .ProjectTo<TOutputModel>(this.All())
                .ToListAsync(cancellationToken))
                .Skip(skip)
                .Take(take); 
    }
}
