namespace Hotel.Domain.Hotel.Factories.Rooms
{
    using Models.Rooms;

    internal class RoomFactory : IRoomFactory
    {
        private string roomNumber = default!;
        private string description = default!;
        private RoomType roomType = default!;

        public IRoomFactory WithRoomNumber(string roomNumber)
        {
            this.roomNumber = roomNumber;
            return this;
        }

        public IRoomFactory WithDescription(string description)
        {
            this.description = description;
            return this;
        }

        public IRoomFactory WithRoomType(string name,
            decimal price,
            int capacityAdults,
            int capacityKids,
            string image,
            string description)
           => this.WithRoomType(new RoomType(name, price, capacityAdults, capacityKids, image, description));

        public IRoomFactory WithRoomType(RoomType roomType)
        {
            this.roomType = roomType;
            return this;
        }

        public Room Build() => new Room(this.roomNumber, this.description, this.roomType);

        public Room Build(string roomNumber, string description, RoomType roomType)
            => this
                .WithRoomNumber(roomNumber)
                .WithDescription(description)
                .WithRoomType(roomType)
                .Build();
    }
}
