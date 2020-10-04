namespace Core.Web.Controllers
{
    using Common;
    using Core.Application.Hotel.Reservations;
    using Core.Application.Hotel.Reservations.Queries.HomePage;
    using Core.Infrastructure.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            var roomTypes = this.reservationQueryRepository
              .GetAllRoomTypes();

            var model = new IndexViewOutputModel
            {
                RoomTypes = roomTypes,
                CheckAvailableRoomsViewModel = new CheckAvailableRoomsViewOutputModel(),
            };

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



        public IActionResult AvailableRooms(string checkIn, string checkOut, int adults, int kids, int page = GlobalConstants.DefaultPageNumber, int perPage = GlobalConstants.PageSize)
        {
            DateTime startDate = DateTime.Parse(checkIn).AddHours(14);
            DateTime endDate = DateTime.Parse(checkOut).AddHours(12);

            var reservedRoomsId = this.reservationQueryRepository
                .GetAllReservedRoomsId(startDate, endDate)
                .ToList();

            var allAvailableRoomModels = this.reservationQueryRepository
                .GetAllRooms()
                .Where(x => !reservedRoomsId.Any(x2 => x2 == x.Id))
                .ToList();

            var rooms = allAvailableRoomModels
               .OrderBy(x => x.RoomTypeCapacityAdults)
               .Skip(perPage * (page - 1))
               .Take(perPage)
               .ToList();

            var pagesCount = (int)Math.Ceiling(allAvailableRoomModels.Count() / (decimal)perPage);

            var model = new AllAvailableRoomsViewModel
            {
                Rooms = rooms.ToList(),
                CurrentPage = page,
                PagesCount = pagesCount,
                Adults = adults,
                Kids = kids,
                CheckIn = startDate.ToString(),
                CheckOut = endDate.ToString(),
            };

            return this.View(model);
        }

        [Authorize]
        public async Task<IActionResult> Book(AllAvailableRoomsViewModel model)
        {
            int totalAdultsCapacity = this.reservationQueryRepository
               .GetAllRooms()
               .Where(x => model.RoomIds.Any(x2 => x2 == x.Id))
               .Select(x => this.reservationQueryRepository.GetRoomTypeCapacityAdultsByIdAsync(x.RoomTypeId).Result)
               .Sum();

            int totalKidsCapacity = this.reservationQueryRepository
               .GetAllRooms()
               .Where(x => model.RoomIds.Any(x2 => x2 == x.Id))
               .Select(x => this.reservationQueryRepository.GetRoomTypeCapacityKidsByIdAsync(x.RoomTypeId).Result)
               .Sum();

            var checkedRooms = this.reservationQueryRepository
               .GetAllRooms()
               .Where(x => model.RoomIds.Any(x2 => x2 == x.Id))
               .ToList();


            if (model.Adults > totalAdultsCapacity ||
                (model.Kids > totalKidsCapacity && (model.Adults + model.Kids) > totalAdultsCapacity))
            {
                this.TempData["capacity"] = $"The capacity of selected rooms is not enough for adults - {model.Adults} and kids - {model.Kids} ";
                return this.Redirect($"/Accommodations/AvailableRooms?checkIn={model.CheckIn}&checkOut={model.CheckOut}&adults={model.Adults}&kids={model.Kids}");
            }

            var rooms = new List<DetailsRoomViewOutputModel>();

            foreach (var id in model.RoomIds)
            {
                var room =  this.reservationQueryRepository.GetRoomViewModelById(id);

                rooms.Add(room);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            model.UserFirstName = user.FirstName;
            model.UserLastName = user.LastName;
            model.UserUserId = user.Id;
            model.UserEmail = user.Email;
            model.PricePerDay = rooms.Sum(x => x.RoomTypePrice);
            model.TotalDays = (int)(DateTime.Parse(model.CheckOut.ToString()).Date - DateTime.Parse(model.CheckIn.ToString()).Date).TotalDays;
            model.TotalAmount = model.PricePerDay * model.TotalDays;
            model.ListOfRoomsInReservation = rooms;

            return this.View(model);
        }

        public async Task<IActionResult> BookRooms(AllAvailableRoomsViewModel model)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            model.UserFirstName = user.FirstName;
            model.UserLastName = user.LastName;
            model.UserUserId = user.Id;
            model.UserEmail = user.Email;

            await this.reservationQueryRepository.CreateReservation(model);

            return this.RedirectToAction("ThankYou");
        }


        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
