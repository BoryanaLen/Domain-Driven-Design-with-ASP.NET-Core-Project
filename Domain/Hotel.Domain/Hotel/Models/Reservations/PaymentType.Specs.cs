namespace Hotel.Domain.Hotel.Models.Reservations
{
    using System;
    using Exceptions;
    using FluentAssertions;
    using Xunit;

    public class PaymentTypeSpecs
    {
        [Fact]
        public void ValidPaymentTypeShouldNotThrowException()
        {
            // Act
            Action act = () => new PaymentType("Cash");

            // Assert
            act.Should().NotThrow<InvalidReservationException>();
        }

        [Fact]
        public void InvalidNameShouldThrowException()
        {
            // Act
            Action act = () => new PaymentType("");

            // Assert
            act.Should().Throw<InvalidReservationException>();
        }
    }
}
