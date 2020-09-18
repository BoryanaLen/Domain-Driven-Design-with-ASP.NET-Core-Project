namespace Hotel.Domain.Hotel.Factories.Customers
{
    using Models.Customers;
    class CustomerFactory : ICustomerFactory
    {
        private string firstName = default!;
        private string lastName = default!;
        private string email = default!;

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

        public Customer Build()
        {
            return new Customer(this.firstName, this.lastName, this.email);
        }

        public Customer Build(string firstName, string lastName, string email)
            => this
                .WithFirstName(firstName)
                .WithLastName(lastName)
                .WithEmail(email)
                .Build();
    }
}
