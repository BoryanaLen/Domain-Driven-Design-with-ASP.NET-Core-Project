namespace Core.Infrastructure.Persistence.Models.CustomerData
{
    using Common.Domain;
    using Common.Domain.Models;

    public class CustomerData :  Entity<int>, IAggregateRoot
    {
        internal CustomerData(string firstName, string lastName, string email, string userId)
        {
            this.UserId = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }

        public string UserId { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }
    }
}
