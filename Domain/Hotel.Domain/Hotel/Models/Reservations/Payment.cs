namespace Hotel.Domain.Hotel.Models.Reservations
{
    using Common;
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

        public DateTime DateOfPayment { get; set; }

        public decimal Amount { get; set; }

        public virtual PaymentType PaymentType { get; set; }

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
