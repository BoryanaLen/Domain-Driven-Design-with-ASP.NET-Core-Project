namespace Infrastructure.Common.Persistence.Models.RoomTypeData
{
    using System;
    using Domain.Hotel.Exceptions;
    using FluentAssertions;
    using Xunit;

    public class RoomTypeSpecs
    {
        [Fact]
        public void ValidRoomTypeShouldNotThrowException()
        {
            // Act
            Action act = () => new RoomTypeData("Studio", 200, 3, 1, "pictures/club-floor-room.jpg", "Valid description text Valid description text");

            // Assert
            act.Should().NotThrow<InvalidRoomException>();
        }

        [Fact]
        public void InvalidNameShouldThrowException()
        {
            // Act
            Action act = () => new RoomTypeData("", 200, 3, 1, "pictures/club-floor-room.jpg", "Valid description text");

            // Assert
            act.Should().Throw<InvalidRoomException>();
        }
    }
}
