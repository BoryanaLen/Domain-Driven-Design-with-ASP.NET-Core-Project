namespace Core.Domain.Hotel.Models.Customers
{
    using Exceptions;
    using Common.Domain.Models;
    using Common.Domain;

    using static ModelConstants.Customer;

    public class Customer: Entity<int>, IAggregateRoot
    {
        internal Customer(string firstName, string lastName, string email, string userId)
        {
            this.ValidateFirstName(firstName);
            this.ValidateLastName(lastName);
            this.ValidateEmail(email);

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.UserId = userId;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string UserId { get; private set; }

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
            => Guard.ForStringLength<InvalidCustomerException>(
                newFirstName,
                MinNameLength,
                MaxNameLength,
                nameof(this.FirstName));

        public void ValidateLastName(string newLastName)
            => Guard.ForStringLength<InvalidCustomerException>(
                newLastName,
                MinNameLength,
                MaxNameLength,
                nameof(this.LastName));

        public void ValidateEmail(string newEmail)
            => Guard.ForValidEmail<InvalidCustomerException>(
                newEmail,
                nameof(this.LastName));
    }
}
