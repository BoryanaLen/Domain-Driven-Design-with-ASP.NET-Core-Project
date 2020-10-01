namespace Core.Infrastructure.Persistence.Models
{
    using Common.Domain.Models;

    public class CustomerData :  Entity<int>
    {
        internal CustomerData(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }
    }
}
