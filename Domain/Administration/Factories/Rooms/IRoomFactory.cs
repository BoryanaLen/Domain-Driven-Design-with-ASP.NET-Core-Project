namespace Domain.Administration.Factories.Rooms
{
    using Common;
    using Models.Rooms;

    public interface IRoomFactory : IFactory<Room>
    {
        IRoomFactory WithRoomNumber(string roomNumber);

        IRoomFactory WithDescription(string description);

        IRoomFactory WithRoomType(RoomType roomType);

        IRoomFactory WithRoomType(
            string name,
            decimal price,
            int capacityAdults,
            int capacityKids,
            string image,
            string description);
    }
}
