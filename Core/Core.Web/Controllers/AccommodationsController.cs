namespace Core.Web.Controllers
{
    using Common;
    using Core.Application.Hotel.Reservations;
    using Core.Application.Hotel.Reservations.Queries.HomePage;
    using Core.Infrastructure.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class AccommodationsController : BaseController
    {
        private readonly IReservationQueryRepository reservationQueryRepository;
        private readonly UserManager<User> userManager;

        public AccommodationsController(
             UserManager<User> userManager,
             IReservationQueryRepository reservationQueryRepository)
        {
            this.userManager = userManager;
            this.reservationQueryRepository = reservationQueryRepository;
        }

        public IActionResult Index()
        {
            var model = this.reservationQueryRepository.GetOffers();

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Check(CheckAvailableRoomsViewOutputModel model)
        {
            if (!this.ModelState.IsValid || (model.CheckIn >= model.CheckOut))
            {
                var roomTypes = this.reservationQueryRepository
                    .GetAllRoomTypes();

                var modelIndex = new IndexViewOutputModel
                {
                    RoomTypes = roomTypes,
                    CheckAvailableRoomsViewModel = model,
                };

                return this.View("Index", modelIndex);
            }

            return this.Redirect($"/Accommodations/AvailableRooms?checkIn={model.CheckIn}&checkOut={model.CheckOut}&adults={model.Adults}&kids={model.Kids}");
        }



        public IActionResult AvailableRooms(string checkIn, string checkOut, int adults, int kids, int page = Constants.DefaultPageNumber, int perPage = Constants.PageSize)
        {
            var model = this.reservationQueryRepository.AvailableRooms(checkIn, checkOut, adults, kids);

            return this.View(model);
        }

        [Authorize]
        public IActionResult Book(AllAvailableRoomsViewModel model)
        {
            var newModel = this.reservationQueryRepository.Book(model);

            return this.View(newModel);
        }

        public async Task<IActionResult> BookRooms(AllAvailableRoomsViewModel model)
        {           
            await this.reservationQueryRepository.BookRooms(model);

            return this.RedirectToAction("ThankYou");
        }


        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
