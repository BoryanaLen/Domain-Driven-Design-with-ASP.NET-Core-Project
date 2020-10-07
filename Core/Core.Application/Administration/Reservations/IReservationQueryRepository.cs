namespace Core.Application.Administration.Reservations
{
    using Common.Application.Contracts;
    using Core.Application.Administration.Dashboard.Queries;
    using Core.Application.Administration.Reservations.Queries;
    using Core.Domain.Administration.Models.Reservations;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReservationQueryRepository : IQueryRepository<Reservation>
    {
        int GetReservedRooms();

        int GetRoomsArrivals();

        int GetRoomsDeparture();

        int GetAllOccupiedRooms();

        Task<int> GetAllReservationsCountAsync();

        Task<int> GetAllRoomsCountAsync();

        IEnumerable<ColumnChartViewModel> IncomesForCurrentYear();

        Task<IndexViewModel> GetCurrentCondition();

        Task<List<PieChartViewModel>> GetRoomsChartData();
    }
}
