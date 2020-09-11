namespace Hotel.Domain.Hotel.Models.Reservations
{
    using Common;
    public class PaymentType : Enumeration
    {
        public static readonly PaymentType Cash = new PaymentType(1, nameof(Cash));
        public static readonly PaymentType DirectBankTransfer = new PaymentType(2, nameof(DirectBankTransfer));
        public static readonly PaymentType PayPal = new PaymentType(3, nameof(PayPal));
        private PaymentType(int value)
            : this(value, FromValue<PaymentType>(value).Name)
        {
        }

        private PaymentType(int value, string name)
            : base(value, name)
        {
        }
    }
}
