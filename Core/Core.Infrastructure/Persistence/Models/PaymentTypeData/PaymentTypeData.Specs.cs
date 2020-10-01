namespace Core.Infrastructure.Persistence.Models.PaymentTypeData
{
    using System;
    using Domain.Hotel.Exceptions;
    using FluentAssertions;
    using Xunit;

    public class PaymentTypeDataSpecs
    {
        [Fact]
        public void ValidPaymentTypeShouldNotThrowException()
        {
            // Act
            Action act = () => new PaymentTypeData("Cash");

            // Assert
            act.Should().NotThrow<InvalidReservationException>();
        }

        [Fact]
        public void InvalidNameShouldThrowException()
        {
            // Act
            Action act = () => new PaymentTypeData("");

            // Assert
            act.Should().Throw<InvalidReservationException>();
        }
    }
}
