namespace Application.Hotel.SpecialOffers.Queries.All
{
    using Common;
    using MediatR;
    using System.Threading.Tasks;

    public class AllSpecialOffersQuery : IRequest<AllSpecialOffersOutputModel>
    {
        private readonly ISpecialOfferRepository specialOfferRepository;

        public AllSpecialOffersQuery(ISpecialOfferRepository specialOfferRepository)
            => this.specialOfferRepository = specialOfferRepository;

        //public async Task<AllSpecialOffersOutputModel> AllSpecialOffersList()
        //{
        //    var allOffersListings = await specialOfferRepository
        //        .GetAllSpecialOffers<AllSpecialOfferOutputModel>();

        //    return new AllSpecialOffersOutputModel(allOffersListings);
        //}
    }
}
