namespace Core.Web.Controllers
{
    using Common;
    using Core.Application.Hotel.SpecialOffers;
    using Core.Application.Hotel.SpecialOffers.Queries.All;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class HomeController : BaseController
    {
        private readonly ISpecialOfferQueryRepository specialOfferRepository;

        public HomeController(ISpecialOfferQueryRepository specialOfferRepository)
        {
            this.specialOfferRepository = specialOfferRepository;
        }

        public async Task<IActionResult> Index()
        {
            var model = await this.specialOfferRepository.GetOffers();

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
