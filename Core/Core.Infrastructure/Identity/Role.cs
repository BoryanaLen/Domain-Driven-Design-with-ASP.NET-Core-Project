namespace Core.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;

    class Role : IdentityRole
    {
        public Role(string name)
            : base(name)
        {
            this.Name = name;
        }
    }
}

