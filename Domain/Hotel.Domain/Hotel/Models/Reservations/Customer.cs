namespace Hotel.Domain.Hotel.Models.Reservations
{
    using Common;
    using Exceptions;

    using static ModelConstants.Customer;

    public class Customer: Entity<int>
    {
        internal Customer(string firstName, string lastName, string email)
        {
            this.ValidateFirstName(firstName);
            this.ValidateLastName(lastName);
            this.ValidateEmail(email);

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public Customer UpdateFirstName(string newFirstName)
        {
            this.ValidateFirstName(newFirstName);
            this.FirstName = newFirstName;

            return this;
        }

        public Customer UpdateLastName(string newLastName)
        {
            this.ValidateLastName(newLastName);
            this.LastName = newLastName;

            return this;
        }

        public Customer UpdateEmail(string newEmail)
        {
            this.ValidateEmail(newEmail);
            this.Email = newEmail;

            return this;
        }

        public void ValidateFirstName(string newFirstName)
            => Guard.ForStringLength<InvalidReservationException>(
                newFirstName,
                MinNameLength,
                MaxNameLength,
                nameof(this.FirstName));

        public void ValidateLastName(string newLastName)
            => Guard.ForStringLength<InvalidReservationException>(
                newLastName,
                MinNameLength,
                MaxNameLength,
                nameof(this.LastName));

        public void ValidateEmail(string newEmail)
            => Guard.ForValidEmail<InvalidReservationException>(
                newEmail,
                nameof(this.LastName));
    }
}
