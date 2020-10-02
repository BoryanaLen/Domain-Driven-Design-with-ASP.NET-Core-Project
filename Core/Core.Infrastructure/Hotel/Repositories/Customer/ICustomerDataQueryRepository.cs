namespace Core.Infrastructure.Hotel.Repositories.Customer
{
    using Common.Application.Contracts;
    using Core.Infrastructure.Persistence.Models.CustomerData;
    using System.Threading.Tasks;

    public interface ICustomerDataQueryRepository : IQueryRepository<CustomerData>
    {
       
    }
}
