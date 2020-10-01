namespace Core.Infrastructure.Identity
{
    using Common.Application.Identity;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser, IUser
    {
        //internal User(string email)
        //    : base(email)
        //    => this.Email = email;

        public User()
        {
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string Address { get; set; } = default!;

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
