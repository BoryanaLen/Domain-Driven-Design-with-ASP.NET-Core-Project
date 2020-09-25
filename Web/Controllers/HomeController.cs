namespace Web.Controllers
{
    using Web.Common;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Application.Administration.SpecialOffers.Queries.All;
    using Application.Administration.SpecialOffers;
    using Microsoft.AspNetCore.Authorization;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeController : BaseController
    {
        private ISpecialOfferRepository specialOfferRepository;

        public HomeController(ISpecialOfferRepository specialOfferRepository)
        {
            this.specialOfferRepository = specialOfferRepository;
        }

        public IActionResult Index()
        {
            var offers =
                this.specialOfferRepository.GetAllSpecialOffersList<AllSpecialOfferOutputModel>();

            var model = new AllSpecialOffersOutputModel()
            {
                SpecialOffers = offers.ToList()
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
