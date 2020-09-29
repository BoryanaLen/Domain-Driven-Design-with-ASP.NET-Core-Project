namespace Application.Administration.SpecialOffers.Queries.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class SpecialOffersQuery
    {
        private const int CarAdsPerPage = 10;

        public string? Title { get; private set; }

        public string? Content { get; private set; }

        public string? ShortContent { get; private set; }

        public int Page { get; set; } = 1;

        public abstract class SpecialOffersQueryHandler
        {
            private readonly ISpecialOfferRepository specialOfferRepository;

            protected SpecialOffersQueryHandler(ISpecialOfferRepository specialOfferRepository)
                => this.specialOfferRepository = specialOfferRepository;

            //protected async Task<IEnumerable<TOutputModel>> GetSpecialOfferListings<TOutputModel>(
            //    CancellationToken cancellationToken = default)
            //{
            //    return await this.specialOfferRepository.GetAllSpecialOffers<TOutputModel>(cancellationToken);
            //}

            //protected async Task<int> GetTotalPages(
            //    CancellationToken cancellationToken = default)
            //{
            //    var totalSpecialOffers = await this.specialOfferRepository.Total(cancellationToken);

            //    return (int)Math.Ceiling((double)totalSpecialOffers / CarAdsPerPage);
            //}
        }
    }
}
