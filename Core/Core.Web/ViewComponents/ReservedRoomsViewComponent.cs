namespace Core.Web.ViewComponents
{
    using Core.Application.Hotel.Reservations.Queries.HomePage;
    using Core.Infrastructure.Hotel.Repositories.Reservation;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReservedRoomsViewComponent : ViewComponent
    {
        private readonly IReservationDataQueryRepository reservationRepository;


        public ReservedRoomsViewComponent(
             IReservationDataQueryRepository reservationRepository)
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
