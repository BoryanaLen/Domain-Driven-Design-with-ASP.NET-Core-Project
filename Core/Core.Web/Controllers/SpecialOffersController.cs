namespace Core.Web.Controllers
{
    using Common;
    using Core.Application.Hotel.SpecialOffers;

    public class SpecialOffersController : BaseController
    {
        private ISpecialOfferQueryRepository specialOfferRepository;

        public SpecialOffersController(ISpecialOfferQueryRepository specialOfferRepository)
        {
            this.specialOfferRepository = specialOfferRepository;
        }
    }
}
