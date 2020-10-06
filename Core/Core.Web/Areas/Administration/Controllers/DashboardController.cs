namespace Core.Web.Areas.Administration.Controllers
{
    using Core.Application.Administration.Dashboard.Queries;
    using Core.Application.Administration.Reservations;
    using Core.Application.Administration.Reservations.Queries;
    using Core.Web.Common;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DashboardController : BaseController
    {
        private readonly IReservationQueryRepository reservationQueryRepository;

        public DashboardController(IReservationQueryRepository reservationQueryRepository)
        {
            this.reservationQueryRepository = reservationQueryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel {};
            int roomsCount = await this.reservationQueryRepository.GetAllRoomsCountAsync();

            viewModel.ReservedRooms = this.reservationQueryRepository.GetReservedRooms();
            viewModel.ExpectedRoomsArrivals = this.reservationQueryRepository.GetRoomsArrivals();
            viewModel.ExpectedRoomsDepartures = this.reservationQueryRepository.GetRoomsDeparture();
            viewModel.RoomsEndOfDay = viewModel.ReservedRooms + viewModel.ExpectedRoomsArrivals - viewModel.ExpectedRoomsDepartures;
            viewModel.OccupiedRooms = this.reservationQueryRepository.GetAllOccupiedRooms();
            viewModel.AvailableRooms = roomsCount - viewModel.OccupiedRooms;

            return this.View(viewModel);
        }

        public async Task<JsonResult> RoomsChart()
        {
            int occupiedRooms = this.reservationQueryRepository.GetAllOccupiedRooms();
            int totalRooms = await this.reservationQueryRepository.GetAllRoomsCountAsync();

            List<PieChartViewModel> data = new List<PieChartViewModel>()
            {
                new PieChartViewModel
                {
                    Status = "Available",
                    Count = totalRooms - occupiedRooms,
                },
                new PieChartViewModel
                {
                    Status = "Occupied",
                    Count = occupiedRooms,
                },
            };

            return this.Json(data);
        }

        public JsonResult IncomesChart()
        {
            List<ColumnChartViewModel> data2 = this.reservationQueryRepository.IncomesForCurrentYear().ToList();

            return this.Json(data2);
        }
    }
}
