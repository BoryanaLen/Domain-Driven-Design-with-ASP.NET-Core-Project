namespace Core.Infrastructure.Identity
{
    using Common.Application.Identity;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser, IUser
    {
        public User()
        {

        }
        public User(
           string firstName,
           string lastName,
           string address,
           string email,
           string userName           
           )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.Email = email;
            this.UserName = userName;
        }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string Address { get; set; } = default!;

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; } = default!;

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; } = default!;

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; } = default!;
    }
}
