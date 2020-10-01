namespace Core.Application.Hotel.SpecialOffers.Queries.All
{
    using Core.Domain.Hotel.Repositories;
    using MediatR;

    public class AllSpecialOffersQuery : IRequest<AllSpecialOffersOutputModel>
    {
        private readonly ISpecialOfferDomainRepository specialOfferRepository;

        public AllSpecialOffersQuery(ISpecialOfferDomainRepository specialOfferRepository)
            => this.specialOfferRepository = specialOfferRepository;

        //public async Task<AllSpecialOffersOutputModel> AllSpecialOffersList()
        //{
        //    var allOffersListings = await specialOfferRepository
        //        .GetAllSpecialOffers<AllSpecialOfferOutputModel>();

        //    return new AllSpecialOffersOutputModel(allOffersListings);
        //}
    }
}
