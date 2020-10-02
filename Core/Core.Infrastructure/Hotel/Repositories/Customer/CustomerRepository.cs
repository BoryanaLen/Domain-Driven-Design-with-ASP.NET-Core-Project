namespace Core.Infrastructure.Hotel.Repositories.Customer
{
    using Core.Application.Hotel.Customers.Queries;
    using Core.Domain.Hotel.Models.Customers;
    using Core.Infrastructure.Persistence;
    using Core.Infrastructure.Persistence.Models.CustomerData;
    using Core.Infrastructure.Persistence.Repositories.CustomerData;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CustomerRepository : DataRepository<HotelSystemDbContext, Customer>,
        ICustomerDataQueryRepository, ICustomerDataDomainRepository
    {
        public CustomerRepository(HotelSystemDbContext db)
           : base(db)
        {

        }

        public Task Save(CustomerData entity, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<CustomerData> FindByUser(string userId)
        {
            var customer = await this.Data
              .Customers
              .FirstOrDefaultAsync(x => x.UserId == userId);

            return customer;
        }
    }
}
