namespace Hotel.Domain.Hotel.Models.Room
{
    using Common;

    public class Room : Entity<int>, IAggregateRoot
    {
        private const int RoomNumberMaxLength = 20;
        private const int DescriptionMaxLength = 1400;

        public Room()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string RoomNumber { get; set; }

        public string RoomTypeId { get; set; }

        public virtual RoomType RoomType { get; set; }

        public string Description { get; set; }

        public string HotelDataId { get; set; }

        public HotelData HotelData { get; set; }

        public ICollection<ReservationRoom> ReservationRooms { get; set; }
    }
}
