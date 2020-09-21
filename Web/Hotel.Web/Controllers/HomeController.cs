namespace Hotel.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Hotel.Common;
    using Hotel.Services.Data;
    using Hotel.Web.Common;
    using Hotel.Web.ViewModels;
    using Hotel.Web.ViewModels.Footer;
    using Hotel.Web.ViewModels.Home;
    using Hotel.Web.ViewModels.SpecialOffers;
    using Microsoft.AspNetCore.Mvc;
    public class HomeController : BaseController
    {
        private readonly ISpecialOffersService specialOffersService;
        private readonly IHotelsService hotelsService;

        public HomeController(ISpecialOffersService specialOffersService, IHotelsService hotelsService)
        {
            this.specialOffersService = specialOffersService;
            this.hotelsService = hotelsService;
        }

        public IActionResult Index()
        {
            var hotel = this.hotelsService.GetHotelByName("Hotel Boryana");

            var offers = this.specialOffersService
                .GetAllSpecialOffers<DetailsSpecialOfferViewModel>()
                .Take(4);

            var model = new HomeViewModel
            {
                SpecialOffers = offers.ToList(),
                FooterViewModel = new FooterViewModel
                {
                    Address = hotel.Address,
                    Manager = hotel.Manager,
                    PhoneNumber = hotel.PhoneNumber,
                },
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
