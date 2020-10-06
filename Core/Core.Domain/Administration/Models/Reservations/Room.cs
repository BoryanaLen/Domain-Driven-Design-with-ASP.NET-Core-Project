namespace Core.Domain.Administration.Models.Reservations
{
    using Common.Domain.Models;
    using Core.Domain.Administration.Exceptions;

    using static ModelConstants.Room;

    public class Room : Entity<int>
    {
        internal Room(
            string roomNumber,
            string description
            )
        {
            this.Validate(roomNumber, description);

            this.RoomNumber = roomNumber;
            this.Description = description;
        }

        public string RoomNumber { get; set; }

        public string Description { get; set; }

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
