namespace Core.Domain.Hotel.Models.Reservations
{
    using Common.Domain.Models;
    using System;

    using static ModelConstants.Payment;

    public class Payment : Entity<int>
    {
        internal Payment(
            DateTime dateOfPayment,
            decimal amount
            )
        {
            this.DateOfPayment = dateOfPayment;
            this.Amount = amount;
        }

        public DateTime DateOfPayment { get; set; }

        public decimal Amount { get; set; }
    }
}
