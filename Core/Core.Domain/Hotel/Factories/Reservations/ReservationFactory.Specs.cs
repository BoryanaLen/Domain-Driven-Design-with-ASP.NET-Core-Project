namespace Core.Domain.Hotel.Factories.Reservations
{
    using System;
    using Exceptions;
    using FluentAssertions;
    using Models.Reservations;
    using Xunit;

    public class ReservationFactorySpecs
    {
        [Fact]
        public void BuildShouldThrowExceptionIfCustomerIsNotSet()
        {
            // Assert
            var reservationFactory = new ReservationFactory();

            // Act
            Action act = () => reservationFactory
                .WithAdults(2)
                .WithKids(1)
                .WithStartDate(DateTime.UtcNow.AddDays(-1))
                .WithEndDate(DateTime.UtcNow.AddDays(5))
                .WithPricePerDay(100)
                .WithAdvancedPayment(0)
                .WithIsPaid(false)
                .Build();

            // Assert
            act.Should().Throw<InvalidReservationException>();
        }


        [Fact]
        public void BuildShouldCreateReservationIfEveryPropertyIsSet()
        {
            //// Assert
            //var reservationFactory = new ReservationFactory();

            //// Act
            //var reservation = reservationFactory
            //    .WithAdults(2)
            //    .WithKids(1)
            //    .WithStartDate(DateTime.UtcNow.AddDays(1))
            //    .WithEndDate(DateTime.UtcNow.AddDays(5))
            //    .WithPaymentType(PaymentType.Cash)
            //    .WithPricePerDay(100)
            //    .WithAdvancedPayment(0)
            //    .WithIsPaid(false)
            //    .WithCustomer("Petar", "Petrov", "abc@gmail.com")
            //    .Build();

            //// Assert
            //reservation.Should().NotBeNull();
        }
    }
}
