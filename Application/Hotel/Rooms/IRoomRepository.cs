namespace Application.Hotel.Accommodations
{
    using Application.Hotel.Accommodations.Queries.Home;
    using System.Collections.Generic;
    using System.Threading;


    public interface IRoomRepository
    {
        public IEnumerable<DetailsRoomTypeViewOutputModel> GetAllRoomTypes(
            CancellationToken cancellationToken = default);
    }
}
