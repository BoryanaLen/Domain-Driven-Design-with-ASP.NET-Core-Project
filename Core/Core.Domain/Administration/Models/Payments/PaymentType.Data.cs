namespace Core.Domain.Administration.Models.Payments
{
    using Common.Domain;
    using System;
    using System.Collections.Generic;

    public class PaymentTypeData : IInitialData
    {
        public Type EntityType => typeof(PaymentType);

        public IEnumerable<object> GetData()
            => new List<PaymentType>
            {
                new PaymentType ("Cash"),

                new PaymentType ("PayPal"),

                new PaymentType ("DirectBankTransfer"),               
            };
    }
}
