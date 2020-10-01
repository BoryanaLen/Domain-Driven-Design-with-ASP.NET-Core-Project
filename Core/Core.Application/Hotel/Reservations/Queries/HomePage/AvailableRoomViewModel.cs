namespace Core.Application.Hotel.Reservations.Queries.HomePage
{
    public class AvailableRoomViewModel
    {
        public int Id { get; set; }

        public string RoomNumber { get; set; } = default!;

        public int RoomTypeId { get; set; } 

        public string RoomTypeName { get; set; } = default!;

        public string RoomTypeImage { get; set; } = default!;

        public decimal RoomTypePrice { get; set; }

        public int RoomTypeCapacityAdults { get; set; }

        public int RoomTypeCapacityKids { get; set; }

        public string Description { get; set; } = default!;

        public bool IsChecked { get; set; }
    }
}
