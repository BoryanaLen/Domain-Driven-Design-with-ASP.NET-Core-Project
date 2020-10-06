namespace Core.Infrastructure.Persistence.Models
{
    using Common.Domain.Models;
    using Core.Domain.Hotel.Models.Reservations;

    public class RoomData : Entity<int>
    {
        internal RoomData(
            string roomNumber,
            string description,
            RoomType roomType
            )
        {     
            this.RoomNumber = roomNumber;
            this.Description = description;

            this.RoomType = roomType;
        }

        private RoomData(
            string roomNumber,
            string description
            )
        {
            this.RoomNumber = roomNumber;
            this.Description = description;

            this.RoomType = default!;
        }

        public string RoomNumber { get; set; }      

        public string Description { get; set; }

        public RoomType RoomType { get; set; }

        public int RoomTypeId { get; set; }
    }
}
