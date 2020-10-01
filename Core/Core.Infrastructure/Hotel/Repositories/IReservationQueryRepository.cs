namespace Core.Infrastructure.Hotel.Repositories
{
    using Common.Application.Contracts;
    using Core.Application.Hotel.Reservations.Queries.HomePage;
    using Core.Infrastructure.Persistence.Models.ReservationData;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IReservationQueryRepository : IQueryRepository<ReservationData>
    {
        public IEnumerable<DetailsRoomTypeViewOutputModel> GetAllRoomTypes(
            CancellationToken cancellationToken = default);

        IEnumerable<int> GetAllReservedRoomsId(DateTime checkIn, DateTime checkOut);

        IEnumerable<AvailableRoomViewModel> GetAllRooms();

        Task<int> GetRoomTypeCapacityAdultsByIdAsync(int id);

        Task<int> GetRoomTypeCapacityKidsByIdAsync(int id);

        DetailsRoomViewOutputModel GetRoomViewModelById(int id);
    }
}
