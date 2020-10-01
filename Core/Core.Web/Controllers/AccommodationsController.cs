namespace Core.Web.Controllers
{
    using Core.Application.Hotel.Reservations.Queries;
    using Core.Application.Hotel.Reservations.Queries.HomePage;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using Common;

    public class AccommodationsController : BaseController
    {

        private readonly IReservationQueryRepository reservationRepository;
        //private readonly IEmailSender emailSender;

        public AccommodationsController(
           IReservationQueryRepository reservationRepository)
        {
            
            this.reservationRepository = reservationRepository;
        }

        public IActionResult Index()
        {
            var roomTypes = this.reservationRepository
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
                var roomTypes = this.reservationRepository
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

            var reservedRoomsId = this.reservationRepository
                .GetAllReservedRoomsId(startDate, endDate)
                .ToList();

            var allAvailableRoomModels = this.reservationRepository
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

        //[Authorize]
        //public async Task<IActionResult> Book(AllAvailableRoomsViewModel model)
        //{
        //    //int totalAdultsCapacity = this.roomsService
        //    //   .GetAllRooms()
        //    //   .Where(x => model.RoomIds.Any(x2 => x2 == x.Id))
        //    //   .Select(x => this.roomTypesService.GetRoomTypeByIdAsync(x.RoomTypeId).Result.CapacityAdults)
        //    //   .Sum();

        //    //int totalKidsCapacity = this.roomsService
        //    //   .GetAllRooms()
        //    //   .Where(x => model.RoomIds.Any(x2 => x2 == x.Id))
        //    //   .Select(x => this.roomTypesService.GetRoomTypeByIdAsync(x.RoomTypeId).Result.CapacityKids)
        //    //   .Sum();

        //    var checkedRooms = this.roomsService
        //       .GetAllRooms()
        //       .Where(x => model.RoomIds.Any(x2 => x2 == x.Id))
        //       .ToList();

        //    int totalAdultsCapacity = 0;
        //    int totalKidsCapacity = 0;

        //    foreach (var room in checkedRooms)
        //    {
        //        var type = await this.roomTypesService.GetRoomTypeByIdAsync(room.RoomTypeId);
        //        totalAdultsCapacity += type.CapacityAdults;
        //        totalKidsCapacity += type.CapacityKids;
        //    }

        //    if (!this.ModelState.IsValid ||
        //        model.Adults > totalAdultsCapacity ||
        //        (model.Kids > totalKidsCapacity && (model.Adults + model.Kids) > totalAdultsCapacity))
        //    {
        //        this.TempData["capacity"] = $"The capacity of selected rooms is not enough for adults - {model.Adults} and kids - {model.Kids} ";
        //        return this.Redirect($"/Accommodations/AvailableRooms?checkIn={model.CheckIn}&checkOut={model.CheckOut}&adults={model.Adults}&kids={model.Kids}");
        //    }

        //    var paymentTypes = this.paymentTypesService
        //     .GetAllPaymentTypes<PaymentTypeDropDownViewModel>();

        //    var rooms = new List<DetailsRoomViewModel>();

        //    foreach (var id in model.RoomIds)
        //    {
        //        var room = await this.roomsService.GetViewModelByIdAsync<DetailsRoomViewModel>(id);

        //        rooms.Add(room);
        //    }

        //    var user = await this.userManager.GetUserAsync(this.User);
        //    model.UserFirstName = user.FirstName;
        //    model.UserLastName = user.LastName;
        //    model.PricePerDay = rooms.Sum(x => x.RoomTypePrice);
        //    model.TotalDays = (int)(DateTime.Parse(model.CheckOut.ToString()).Date - DateTime.Parse(model.CheckIn.ToString()).Date).TotalDays;
        //    model.TotalAmount = model.PricePerDay * model.TotalDays;
        //    model.ListOfRoomsInReservation = rooms;
        //    model.ListOfPaymentTypes = paymentTypes;

        //    return this.View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> BookRooms(AllAvailableRoomsViewModel model)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.View(model);
        //    }

        //    var user = await this.userManager.GetUserAsync(this.User);

        //    string reservationStatusId = this.reservationStatusesService.GetReserVationStatusByName("Pending").Id;

        //    Reservation reservation = new Reservation
        //    {
        //        StartDate = DateTime.Parse(model.CheckIn).AddHours(14),
        //        EndDate = DateTime.Parse(model.CheckOut).AddHours(12),
        //        UserId = user.Id,
        //        Adults = model.Adults,
        //        Kids = model.Kids,
        //        ReservationStatusId = reservationStatusId,
        //        PaymentTypeId = model.PaymentTypeId,
        //        PricePerDay = model.PricePerDay,
        //        TotalAmount = model.TotalAmount,
        //    };

        //    foreach (var id in model.RoomIds)
        //    {
        //        var reservationRoom = new ReservationRoom
        //        {
        //            ReservationId = reservation.Id,
        //            RoomId = id,
        //        };

        //        reservation.ReservationRooms.Add(reservationRoom);
        //    }

        //    await this.reservationsService.AddReservationAsync(reservation);

        //    var confirmationReservation = await this.reservationsService.GetViewModelByIdAsync<ConfirmationReservationViewModel>(reservation.Id);

        //    var roomIds = this.reservationRoomsService
        //        .GetAllRoomsByReservationId(reservation.Id).ToList();

        //    foreach (var id in roomIds)
        //    {
        //        var room = await this.roomsService.GetViewModelByIdAsync<DetailsRoomViewModel>(id);
        //        confirmationReservation.Rooms.Add(room);
        //    }

        //    var emailContent = this.GenerateEmailContent(confirmationReservation);

        //    var emailAttachment = new EmailAttachment
        //    {
        //        Content = Encoding.UTF8.GetBytes(emailContent),
        //        FileName = "Confirmation.doc",
        //        MimeType = "application/msword",
        //    };

        //    var attachments = new List<EmailAttachment> { emailAttachment };

        //    await this.emailSender.SendEmailAsync(
        //            GlobalConstants.SystemEmail,
        //            GlobalConstants.SystemName,
        //            user.Email,
        //            "Booking Confirmation",
        //            $"Please find attaced file with details for your reservation No{reservation.Id}",
        //            attachments);

        //    return this.RedirectToAction("ThankYou");
        //}

        //public IActionResult ThankYou()
        //{
        //    return this.View();
        //}

        //private string GenerateEmailContent(ConfirmationReservationViewModel confirmationReservationViewModel)
        //{
        //    int totalDays = (int)(confirmationReservationViewModel.EndDate.Date - confirmationReservationViewModel.StartDate.Date).TotalDays;

        //    var guestInfoHtml = string.Format(
        //       GlobalConstants.GuestHtmlInfo,
        //       confirmationReservationViewModel.UserFirstName + " " + confirmationReservationViewModel.UserLastName,
        //       confirmationReservationViewModel.UserPhoneNumber,
        //       confirmationReservationViewModel.UserEmail);

        //    StringBuilder sb = new StringBuilder();

        //    foreach (var room in confirmationReservationViewModel.Rooms)
        //    {
        //        var roomsInfoHtml = string.Format(
        //           GlobalConstants.RoomsHtmlInfo,
        //           room.RoomTypeName,
        //           room.RoomTypeCapacityAdults,
        //           room.RoomTypeCapacityKids,
        //           room.RoomTypePrice,
        //           room.RoomTypePrice * totalDays);

        //        sb.AppendLine(roomsInfoHtml);
        //    }

        //    var reservationInfoHtml = string.Format(
        //        GlobalConstants.ReservationHtmlInfo,
        //        confirmationReservationViewModel.StartDate.ToString("dd/MM/yyyy"),
        //        confirmationReservationViewModel.EndDate.ToString("dd/MM/yyyy"),
        //        totalDays,
        //        confirmationReservationViewModel.Adults,
        //        confirmationReservationViewModel.Kids);

        //    var paymentInfoHtml = string.Format(
        //       GlobalConstants.PaymentHtmlInfo,
        //       confirmationReservationViewModel.TotalAmount,
        //       confirmationReservationViewModel.TotalAmount * 0.3M,
        //       confirmationReservationViewModel.PaymentType.Name);

        //    var path = GlobalConstants.ReservationReceiptEmailHtmlPath;
        //    var doc = new HtmlDocument();
        //    doc.Load(path);

        //    var content = doc.Text;

        //    content = content.Replace(GlobalConstants.ReservationInfoPlaceholder, reservationInfoHtml)
        //        .Replace(GlobalConstants.PaymentInfoPlaceholder, paymentInfoHtml)
        //        .Replace(GlobalConstants.RoomsInfoPlaceholder, sb.ToString())
        //        .Replace(GlobalConstants.GuestInfoPlaceholder, guestInfoHtml);

        //    return content;
        //}
    }
}
