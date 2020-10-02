namespace Core.Infrastructure.Hotel.Repositories.Reservation
{
    using Common.Application.Contracts;
    using Core.Application.Hotel.Reservations.Queries.HomePage;
    using Core.Infrastructure.Persistence.Models.ReservationData;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IReservationDataQueryRepository : IQueryRepository<ReservationData>
    {
        IEnumerable<int> GetAllReservedRoomsId(DateTime checkIn, DateTime checkOut);

        IEnumerable<AvailableRoomViewModel> GetAllRooms();

        Task<int> GetRoomTypeCapacityAdultsByIdAsync(int id);

        Task<int> GetRoomTypeCapacityKidsByIdAsync(int id);

        DetailsRoomViewOutputModel GetRoomViewModelById(int id);

        IEnumerable<DetailsRoomTypeViewOutputModel> GetAllRoomTypes();
    }
}
