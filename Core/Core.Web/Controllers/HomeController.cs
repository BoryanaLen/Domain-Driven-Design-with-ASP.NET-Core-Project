namespace Core.Web.Controllers
{
    using Core.Application.Hotel.SpecialOffers.Queries.All;
    using Common;
    using Microsoft.AspNetCore.Mvc;
    using Core.Infrastructure.Hotel.Repositories;

    public class HomeController : BaseController
    {
        private readonly ISpecialOfferQueryRepository specialOfferRepository;

        public HomeController(ISpecialOfferQueryRepository specialOfferRepository)
        {
            this.specialOfferRepository = specialOfferRepository;
        }

        public IActionResult Index()
        {
            var listOffers =
                this.specialOfferRepository.GetAllSpecialOffersList();

            var model = new AllSpecialOffersOutputModel()
            {
                SpecialOffers = listOffers,
            };

            return this.View(model);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode == StatusCodes.NotFound)
            {
                return this.Redirect($"/Error/{StatusCodes.NotFound}");
            }

            return this.Redirect($"/Error/{StatusCodes.InternalServerError}");
        }
    }
}
