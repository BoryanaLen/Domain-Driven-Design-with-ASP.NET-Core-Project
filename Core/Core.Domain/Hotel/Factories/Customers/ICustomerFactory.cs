namespace Core.Domain.Hotel.Factories.Customers
{
    using Common.Domain;
    using Models.Customers;

    public interface ICustomerFactory : IFactory<Customer>
    {
        ICustomerFactory WithFirstName(string firstName);

        ICustomerFactory WithLastName(string lastName);

        ICustomerFactory WithEmail(string email);
    }
}
