namespace Common.Application.Contracts
{
    using System.Collections.Generic;

    public interface ICurrentUser
    {
        string UserId { get; }

        string FirstName { get; }

        string LastName { get; }

        string Email { get; }


        IEnumerable<string> Roles { get; }
    }
}
