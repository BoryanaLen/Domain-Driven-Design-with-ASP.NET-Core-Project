namespace Core.Infrastructure.Persistence.Models
{
    using Common.Domain.Models;
    using Core.Domain.Administration.Models.Payments;
    using System;

    internal class PaymentData : Entity<int>
    {
        public DateTime DateOfPayment { get; set; }

        public decimal Amount { get; set; }

        public PaymentType PaymentType { get; set; } = default!;
    }
}
