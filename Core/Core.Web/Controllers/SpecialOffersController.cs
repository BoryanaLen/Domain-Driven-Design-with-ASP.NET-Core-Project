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

        //public async Task<IActionResult> All(int page = GlobalConstants.DefaultPageNumber, int perPage = GlobalConstants.PageSize)
        //{
        //    var offers =
        //        this.specialOfferRepository
        //        .GetAllSpecialOffersList<AllSpecialOfferOutputModel>()
        //        .OrderByDescending(x => x.Id);

        //    int offersCount = offers.Count();

        //    var pagesCount = (int)Math.Ceiling(offersCount / (decimal)perPage);

        //    var model = new AllSpecialOffersOutputModel()
        //    {
        //        SpecialOffers = offers.ToList(),
        //        CurrentPage = page,
        //        PagesCount = pagesCount,
        //    };

        //    return this.View(model);
        //}

        //public async Task<IActionResult> Details(string id)
        //{
        //    var offer = await this.specialOffersService.GetViewModelByIdAsync<DetailsSpecialOfferViewModel>(id);

        //    return this.View(offer);
        //}
    }
}
