namespace Core.Domain.Hotel.Models.Reservations
{
    using Exceptions;
    using Common.Domain.Models;

    using static ModelConstants.Room;

    public class Room : Entity<int>
    {
        internal Room(
            string roomNumber,
            string description,
            RoomType roomType
            )
        {
            this.Validate(roomNumber, description);        

            this.RoomNumber = roomNumber;
            this.Description = description;

            this.RoomType = roomType;
        }

        private Room(
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

        private void Validate(string roomNumber, string description)
        {
            Guard.ForStringLength<InvalidRoomException>(
                roomNumber,
                MinRoomNumberLength,
                MaxRoomNumberLength,
                nameof(this.RoomNumber));

            Guard.ForStringLength<InvalidRoomException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(this.Description));
        }
    }
}
