﻿namespace Web.Controllers
{
    using Application.Administration.SpecialOffers;

    public class SpecialOffersController : BaseController
    {
        private ISpecialOfferRepository specialOfferRepository;

        public SpecialOffersController(ISpecialOfferRepository specialOfferRepository)
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
