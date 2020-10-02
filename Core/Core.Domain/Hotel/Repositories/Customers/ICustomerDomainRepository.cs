namespace Core.Domain.Hotel.Repositories.Customers
{
    using Common.Domain;
    using Core.Domain.Hotel.Models.Customers;
    using System.Threading.Tasks;

    public interface ICustomerDomainRepository : IDomainRepository<Customer>
    {
        Task<Customer> FindByUser(string userName);
    }
}
