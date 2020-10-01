namespace Core.Application.Hotel.Reservations.Queries
{
    using HomePage;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public interface IReservationQueryRepository
    {
        public IEnumerable<DetailsRoomTypeViewOutputModel> GetAllRoomTypes(
            CancellationToken cancellationToken = default);

        IEnumerable<int> GetAllReservedRoomsId(DateTime checkIn, DateTime checkOut);

        IEnumerable<AvailableRoomViewModel> GetAllRooms();
    }
}
