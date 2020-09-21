namespace Hotel.Domain.Administration.Models.SpecialOffer
{
    using System;
    using Exceptions;
    using FluentAssertions;
    using Xunit;

    public class SpecialOfferSpecs
    {
        [Fact]
        public void ValidSpecialOfferShouldNotThrowException()
        {
            // Act
            Action act = () => new SpecialOffer("Valid name", "Valid content Valid content Valid content Valid content Valid content Valid content Valid content", "Valid short content");

            // Assert
            act.Should().NotThrow<InvalidSpecialOfferException>();
        }

        [Fact]
        public void InvalidTotleShouldThrowException()
        {
            // Act
            Action act = () => new SpecialOffer("Valid name", "Valid content Valid content Valid content Valid content Valid content Valid content Valid content", "Valid short content");

            // Assert
            act.Should().Throw<InvalidSpecialOfferException>();
        }
    }
}
