namespace Core.Domain.Administration.Models.Payments
{
    using Common.Domain.Models;
    using Core.Domain.Administration.Exceptions;

    using static ModelConstants.Common;

    public class PaymentType: Entity<int>
    {
        internal PaymentType(
           string name)
        {
            this.Validate(name);

            this.Name = name;
        }

        public string Name { get; private set; }

        private void Validate(string name)
        {
            this.ValidateName(name);
        }

        private void ValidateName(string name)
           => Guard.ForStringLength<InvalidPaymentException>(
               name,
               MinNameLength,
               MaxNameLength,
               nameof(this.Name));
    }
}
