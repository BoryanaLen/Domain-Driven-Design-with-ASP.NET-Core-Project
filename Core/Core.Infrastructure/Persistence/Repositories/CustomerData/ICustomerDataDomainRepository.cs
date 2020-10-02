namespace Core.Infrastructure.Persistence.Repositories.CustomerData
{
    using Common.Domain;
    using Models.CustomerData;
    using System.Threading.Tasks;

    public interface ICustomerDataDomainRepository : IDomainRepository<CustomerData>
    {
        Task<CustomerData> FindByUser(string userId);
    }
}
