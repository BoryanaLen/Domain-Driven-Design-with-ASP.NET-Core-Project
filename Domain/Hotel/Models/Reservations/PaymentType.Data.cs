namespace Domain.Hotel.Models.Reservations
{
    using Common;
    using System;
    using System.Collections.Generic;

    class PaymentTypeData : IInitialData
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
