namespace Infrastructure.Common.Persistence.Models.PaymentTypeData
{
    using Domain.Common;
    using System;
    using System.Collections.Generic;

    public class PaymentTypeDataData : IInitialData
    {
        public Type EntityType => typeof(PaymentTypeData);

        public IEnumerable<object> GetData()
            => new List<PaymentTypeData>
            {
                new PaymentTypeData ("Cash"),

                new PaymentTypeData ("PayPal"),

                new PaymentTypeData ("DirectBankTransfer"),               
            };
    }
}
