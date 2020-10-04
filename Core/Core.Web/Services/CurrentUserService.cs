﻿namespace Core.Web.Services
{ 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using global::Common.Application.Contracts;
    using Microsoft.AspNetCore.Http;

    public class CurrentUserService : ICurrentUser
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            this.UserId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            this.Roles = user
                .FindAll(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);

            this.Email = user.FindFirstValue(ClaimTypes.Email);
        }

        public string UserId { get; }

        public IEnumerable<string> Roles { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }
    }
}
