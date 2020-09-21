namespace Hotel.Domain.Hotel.Models.Reservations
{
    using Common.Models;
    using Exceptions;
    using System;

    using static ModelConstants.Payment;

    public class Payment : Entity<int>
    {
        internal Payment(
            DateTime dateOfPayment,
            decimal amount,
            PaymentType paymentType
            )
        {
            this.Validate(amount);

            this.PaymentType = paymentType;

            this.DateOfPayment = dateOfPayment;
            this.Amount = amount;

        }

        private Payment(DateTime dateOfPayment, decimal amount)
        {
            this.DateOfPayment = dateOfPayment;
            this.Amount = amount;

            this.PaymentType = default!;
        }

        public DateTime DateOfPayment { get; set; }

        public decimal Amount { get; set; }

        public PaymentType PaymentType { get; set; }

        private void Validate(decimal amount)
        {
            this.ValidateAmount(amount);
        }

        private void ValidateAmount(decimal amount)
           => Guard.AgainstOutOfRange<InvalidReservationException>(
                amount,
                Zero,
                decimal.MaxValue,
                nameof(this.Amount));
    }
}
