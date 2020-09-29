namespace Application.Hotel.Accommodations.Queries.Home
{
    using System.Collections.Generic;

    public class IndexViewOutputModel
    {
        public IEnumerable<DetailsRoomTypeViewOutputModel> RoomTypes { get; set; } = default!;

        public CheckAvailableRoomsViewOutputModel CheckAvailableRoomsViewModel { get; set; } = default!;
    }
}
