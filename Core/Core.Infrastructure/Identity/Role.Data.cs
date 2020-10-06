namespace Core.Infrastructure.Identity
{
    using Common.Domain;
    using System;
    using System.Collections.Generic;

    class RoleData : IInitialData
    {
        public Type EntityType => typeof(Role);

        public IEnumerable<object> GetData()
            => new List<Role>
            {
                new Role("Administrator"),
                 new Role("User")
            };
    }
}
