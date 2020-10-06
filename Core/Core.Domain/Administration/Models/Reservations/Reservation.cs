namespace Core.Domain.Administration.Models.Reservations
{
    using Common.Domain;
    using Common.Domain.Models;
    using Core.Domain.Administration.Exceptions;
    using System;

    using static ModelConstants.Common;

    public class Reservation : Entity<int>, IAggregateRoot
    {
        internal Reservation(
            DateTime startDate,
            DateTime endDate,
            decimal totalAmount
            )
        {
            this.Validate(startDate, endDate, totalAmount);

            this.StartDate = startDate;
            this.EndDate = endDate;
            this.TotalAmount = totalAmount;
        }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public decimal TotalAmount { get; set; }

        private void Validate(DateTime startDate, DateTime endDate, decimal totalAmount)
        {
            this.ValidateStartDateAndEndDate(startDate, endDate);
            this.ValidateTotalAmount(totalAmount);
        }

        private void ValidateStartDateAndEndDate(DateTime startDate, DateTime endDate)
            => Guard.AgainstOutOfRangeStartAndEndDates<InvalidReservationException>(
                startDate,
                endDate);

        private void ValidateTotalAmount(decimal pricePerDay)
            => Guard.AgainstOutOfRange<InvalidReservationException>(
                pricePerDay,
                Zero,
                decimal.MaxValue,
                nameof(this.TotalAmount));

    }
}
