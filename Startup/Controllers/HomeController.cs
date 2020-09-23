namespace Web.Controllers
{
    using System.Linq;
    using Web.Common;
    using Microsoft.AspNetCore.Mvc;
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            //var hotel = this.hotelsService.GetHotelByName("Hotel Boryana");

            //var offers = this.specialOffersService
            //    .GetAllSpecialOffers<DetailsSpecialOfferViewModel>()
            //    .Take(4);

            //var model = new HomeViewModel
            //{
            //    SpecialOffers = offers.ToList(),
            //    FooterViewModel = new FooterViewModel
            //    {
            //        Address = hotel.Address,
            //        Manager = hotel.Manager,
            //        PhoneNumber = hotel.PhoneNumber,
            //    },
            //};

            return this.View();
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
