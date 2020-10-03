namespace Core.Domain.Hotel.Factories.Customers
{
    using Models.Customers;
    class CustomerFactory : ICustomerFactory
    {
        private string firstName = default!;
        private string lastName = default!;
        private string email = default!;
        private string userId = default!;

        public ICustomerFactory WithEmail(string email)
        {
            this.email = email;
            return this;
        }

        public ICustomerFactory WithFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public ICustomerFactory WithLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public ICustomerFactory WithUserId(string userId)
        {
            this.userId = userId;
            return this;
        }

        public Customer Build()
        {
            return new Customer(this.firstName, this.lastName, this.email, this.userId);
        }

        public Customer Build(string firstName, string lastName, string email)
            => this
                .WithFirstName(firstName)
                .WithLastName(lastName)
                .WithEmail(email)
                .Build();
    }
}
