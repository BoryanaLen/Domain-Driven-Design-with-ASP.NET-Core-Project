namespace Core.Infrastructure.Hotel.Repositories
{
    using Common.Application.Contracts;
    using Core.Application.Hotel.Reservations.Queries.HomePage;
    using Core.Infrastructure.Persistence.Models.ReservationData;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public interface IReservationQueryRepository : IQueryRepository<ReservationData>
    {
        public IEnumerable<DetailsRoomTypeViewOutputModel> GetAllRoomTypes(
            CancellationToken cancellationToken = default);

        IEnumerable<int> GetAllReservedRoomsId(DateTime checkIn, DateTime checkOut);

        IEnumerable<AvailableRoomViewModel> GetAllRooms();
    }
}
