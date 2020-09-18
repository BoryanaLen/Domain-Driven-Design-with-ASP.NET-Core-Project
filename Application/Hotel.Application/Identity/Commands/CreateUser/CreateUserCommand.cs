namespace Hotel.Application.Identity.Commands.CreateUser
{
    using System.Threading;
    using System.Threading.Tasks;

    using Common;
    using Hotel.Domain.Hotel.Factories.Customers;
    using MediatR;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string Email { get; set; } = default!;

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;
            private readonly ICustomerFactory customerFactory;
            //private readonly ICustomerRepository dealerRepository;

            public CreateUserCommandHandler(
                IIdentity identity, 
                ICustomerFactory customerFactory) 
                //IDealerRepository dealerRepository)
            {
                this.identity = identity;
                this.customerFactory = customerFactory;
                //this.dealerRepository = dealerRepository;
            }

            public async Task<Result> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Register(request);

                if (!result.Succeeded)
                {
                    return result;
                }

                var user = result.Data;

                var customer = this.customerFactory
                    .WithFirstName(request.FirstName)
                    .WithLastName(request.LastName)
                    .WithEmail(request.LastName)
                    .Build();

                //user.BecomeCustomer(customer);

                //await this.dealerRepository.Save(dealer, cancellationToken);

                return result;
            }
        }
    }
}