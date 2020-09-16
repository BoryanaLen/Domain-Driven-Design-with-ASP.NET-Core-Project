namespace Hotel.Domain.Hotel.Models.Rooms
{
    using System;
    using Exceptions;
    using FluentAssertions;
    using Xunit;

    public class RoomTypeSpecs
    {
        [Fact]
        public void ValidRoomTypeShouldNotThrowException()
        {
            // Act
            Action act = () => new RoomType("Studio", 200, 3, 1, "pictures/club-floor-room.jpg", "Valid description text");

            // Assert
            act.Should().NotThrow<InvalidRoomException>();
        }

        [Fact]
        public void InvalidNameShouldThrowException()
        {
            // Act
            Action act = () => new RoomType("", 200, 3, 1, "pictures/club-floor-room.jpg", "Valid description text");

            // Assert
            act.Should().Throw<InvalidRoomException>();
        }
    }
}
