namespace Core.Application.Hotel.Customers
{
    using Common.Application.Contracts;
    using Core.Domain.Hotel.Models.Customers;

    public interface ICustomerQueryRepository : IQueryRepository<Customer>
    {
       
    }
}
