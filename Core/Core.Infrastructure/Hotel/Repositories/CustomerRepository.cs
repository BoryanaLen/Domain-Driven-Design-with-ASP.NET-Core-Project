namespace Core.Infrastructure.Hotel.Repositories
{
    using AutoMapper;
    using Core.Application.Hotel.Customers;
    using Core.Domain.Hotel.Models.Customers;
    using Core.Domain.Hotel.Repositories.Customers;
    using Core.Infrastructure.Persistence;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    internal class CustomerRepository : DataRepository<IHotelDbContext, Customer>,
        ICustomerDomainRepository,
        ICustomerQueryRepository
    {

        private readonly IMapper mapper;

        public CustomerRepository(HotelSystemDbContext db, IMapper mapper)
           : base(db)
        {
            this.mapper = mapper;
        }

        public async Task<Customer> FindByUser(string userId)
        {
            var customer = await this.Data
              .Customers
              .FirstOrDefaultAsync(x => x.UserId == userId);

            return customer;
        }
    }
}
