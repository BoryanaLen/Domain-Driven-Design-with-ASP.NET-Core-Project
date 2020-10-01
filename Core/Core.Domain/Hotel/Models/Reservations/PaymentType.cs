namespace Core.Domain.Hotel.Models.Reservations
{
    using Common.Domain.Models;
    using Domain.Hotel.Exceptions;

    using static ModelConstants.Common;

    public class PaymentType : Entity<int>
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
           => Guard.ForStringLength<InvalidReservationException>(
               name,
               MinNameLength,
               MaxNameLength,
               nameof(this.Name));
    }
}
