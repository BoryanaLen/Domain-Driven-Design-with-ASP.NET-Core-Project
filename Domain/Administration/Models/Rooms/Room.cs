namespace Domain.Administration.Models.Rooms
{
    using Common.Models;
    using Exceptions;
    using Common;

    using System.Collections.Generic;
    using System.Linq;

    using static ModelConstants.Room;

    public class Room : Entity<int>, IAggregateRoot
    {
        //private static readonly IEnumerable<RoomType> AllowedRoomTypes
        //     = new RoomTypeData().GetData().Cast<RoomType>();

        internal Room(
            string roomNumber,
            string description,
            RoomType roomType
            )
        {
            this.Validate(roomNumber, description);
            //this.ValidateRoomType(roomType);           

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

        //private void ValidateRoomType(RoomType roomType)
        //{
        //    var roomTypeName = roomType?.Name;

        //    if (AllowedRoomTypes.Any(c => c.Name == roomTypeName))
        //    {
        //        return;
        //    }

        //    var allowedRoomTypesNames = string.Join(", ", AllowedRoomTypes.Select(c => $"'{c.Name}'"));

        //    throw new InvalidRoomException($"'{roomTypeName}' is not a valid room type. Allowed values are: {allowedRoomTypesNames}.");
        //}
    }
}
