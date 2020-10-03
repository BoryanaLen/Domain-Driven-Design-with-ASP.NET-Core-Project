namespace Core.Domain.Administration.Models.Payments
{
    using System;
    using Domain.Hotel.Exceptions;
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
