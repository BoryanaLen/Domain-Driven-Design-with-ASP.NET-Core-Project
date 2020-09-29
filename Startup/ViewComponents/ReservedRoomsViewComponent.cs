namespace Hotel.Web.ViewComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Hotel.Reservations;
    using Application.Hotel.Reservations.Queries.HomePage;
    using Microsoft.AspNetCore.Mvc;

    public class ReservedRoomsViewComponent : ViewComponent
    {
        private readonly IReservationRepository reservationRepository;


        public ReservedRoomsViewComponent(
             IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(string checkIn, string checkOut)
        {
            var items = await this.GetRoomsAsync(checkIn, checkOut);

            return this.View(items);
        }

        private async Task<List<AvailableRoomViewModel>> GetRoomsAsync(string checkIn, string checkOut)
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

            return allAvailableRoomModels;
        }
    }
}
