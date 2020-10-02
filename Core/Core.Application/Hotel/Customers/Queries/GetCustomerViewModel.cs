namespace Core.Application.Hotel.Customers.Queries
{
    using System;

    public class GetCustomerViewModel
    {
        public string UserId { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string Email { get; set; } = default!;
    }
}
