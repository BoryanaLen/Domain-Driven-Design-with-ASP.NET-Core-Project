namespace Hotel.Domain.Hotel.Models.Customers
{
    using System.Text.RegularExpressions;

    using Exceptions;
    using Common.Models;

    using static ModelConstants.PhoneNumber;

    public class PhoneNumber : ValueObject
    {
        internal PhoneNumber(string number)
        {
            this.Validate(number);

            if (!Regex.IsMatch(number, PhoneNumberRegularExpression))
            {
                throw new InvalidCustomerException("Phone number must start with a '+' and contain only digits afterwards.");
            }

            this.Number = number;
        }

        public string Number { get; }

        public static implicit operator string(PhoneNumber number) => number.Number;

        public static implicit operator PhoneNumber(string number) => new PhoneNumber(number);

        private void Validate(string phoneNumber)
            => Guard.ForStringLength<InvalidCustomerException>(
                phoneNumber,
                MinPhoneNumberLength,
                MaxPhoneNumberLength,
                nameof(PhoneNumber));
    }
}
