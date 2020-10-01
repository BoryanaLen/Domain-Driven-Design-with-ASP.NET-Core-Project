namespace Core.Domain.Hotel.Models.Reservations
{
    using System;

    using static ModelConstants.Payment;

    public class Payment 
    {
        internal Payment(
            DateTime dateOfPayment,
            decimal amount,
            PaymentType paymentType
            )
        {
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
    }
}
