namespace Core.Application.Administration.Dashboard.Queries
{
    public class IndexViewModel
    {
        public int ReservedRooms { get; set; }

        public int ExpectedRoomsArrivals { get; set; }

        public int ExpectedRoomsDepartures { get; set; }

        public int RoomsEndOfDay { get; set; }

        public int OccupiedRooms { get; set; }

        public int AvailableRooms { get; set; }

        //public AllReservationsViewModel AllReservations { get; set; }
    }
}
