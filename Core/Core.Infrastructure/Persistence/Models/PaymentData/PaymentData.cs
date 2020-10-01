namespace Core.Infrastructure.Persistence.Models.PaymentData
{
    using Common.Domain.Models;
    using PaymentTypeData;
    using System;

    public class PaymentData: Entity<int>
    {
        internal PaymentData(
            DateTime dateOfPayment,
            decimal amount,
            PaymentTypeData paymentType)
        {

            this.PaymentType = paymentType;

            this.DateOfPayment = dateOfPayment;
            this.Amount = amount;

        }

        private PaymentData(
            DateTime dateOfPayment,
            decimal amount
            )
        {
            this.PaymentType = default!;

            this.DateOfPayment = dateOfPayment;
            this.Amount = amount;
        }

        public DateTime DateOfPayment { get; private set; }

        public decimal Amount { get; private set; }

        public PaymentTypeData PaymentType { get; private set; }
    }
}
