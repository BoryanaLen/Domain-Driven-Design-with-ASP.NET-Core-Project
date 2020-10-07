namespace Core.Web.Services
{ 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using Core.Infrastructure.Identity;
    using global::Common.Application.Contracts;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;

    public class CurrentUserService : ICurrentUser
    {
        private readonly UserManager<User> userManager;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            var user = userManager.GetUserAsync(httpContextAccessor.HttpContext.User).Result;

            if (user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            this.UserId = user.Id;

            this.Email = user.Email;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
        }

        public string UserId { get; }

        public IEnumerable<string> Roles { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }
    }
}
