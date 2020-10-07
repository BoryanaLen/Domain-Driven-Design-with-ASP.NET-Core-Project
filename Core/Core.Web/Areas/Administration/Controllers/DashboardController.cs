namespace Core.Web.Areas.Administration.Controllers
{
    using Core.Application.Administration.Reservations;
    using Core.Application.Administration.Reservations.Queries;
    using Core.Web.Common;
    using Microsoft.AspNetCore.Mvc;
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
            var viewModel = await this.reservationQueryRepository.GetCurrentCondition();

            return this.View(viewModel);
        }

        public async Task<JsonResult> RoomsChart()
        {
            var data = await this.reservationQueryRepository.GetRoomsChartData();

            return this.Json(data);
        }

        public JsonResult IncomesChart()
        {
            List<ColumnChartViewModel> data2 = this.reservationQueryRepository.IncomesForCurrentYear().ToList();

            return this.Json(data2);
        }
    }
}
