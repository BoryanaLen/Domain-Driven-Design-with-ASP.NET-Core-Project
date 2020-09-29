namespace Infrastructure.Common.Persistence.Models.SpecialOfferData
{
    using System;
    using Domain.Hotel.Exceptions;
    using FluentAssertions;
    using Xunit;

    public class SpecialOfferSpecs
    {
        [Fact]
        public void ValidSpecialOfferShouldNotThrowException()
        {
            // Act
            Action act = () => new SpecialOfferData(
                "Valid name name", 
                "Valid content Valid content Valid content Valid content Valid content Valid content Valid content Valid content Valid content Valid content Valid content Valid content Valid content Valid content Valid content Valid content Valid content Valid content Valid content Valid content Valid content Valid content Valid content Valid content",
                "Valid short content Valid short content");

            // Assert
            act.Should().NotThrow<Domain.Hotel.Exceptions.InvalidSpecialOfferException>();
        }

        [Fact]
        public void InvalidTotleShouldThrowException()
        {
            // Act
            Action act = () => new SpecialOfferData("Valid name", "Valid content Valid content Valid content Valid content Valid content Valid content Valid content", "Valid short content");

            // Assert
            act.Should().Throw<InvalidSpecialOfferException>();
        }
    }
}
