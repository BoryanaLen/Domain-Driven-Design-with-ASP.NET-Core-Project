namespace Hotel.Domain.Hotel.Models.Rooms
{
    using FakeItEasy;
    using System;

    public class RoomTypeFakes
    {
        public const string ValidRoomTypeName = "Studio";

        public class RoomTypeDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(RoomType);

            public object? Create(Type type)
                => new RoomType(ValidRoomTypeName, 200, 3, 1, "pictures/club-floor-room.jpg", "Valid description text");

            public Priority Priority => Priority.Default;
        }
    }
}
