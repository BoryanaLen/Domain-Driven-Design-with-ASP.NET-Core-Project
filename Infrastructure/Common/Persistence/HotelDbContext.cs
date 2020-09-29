namespace Infrastructure.Common.Persistence
{
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Domain.Common.Models;
    using Infrastructure.Common.Persistence.Models.ReservationData;
    using Infrastructure.Common.Persistence.Models.RoomData;
    using Infrastructure.Common.Persistence.Models.RoomTypeData;
    using Infrastructure.Common.Persistence.Models.PaymentTypeData;
    using Infrastructure.Common.Persistence.Models.SpecialOfferData;
    using Infrastructure.Common.Persistence.Models.PaymentData;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Infrastructure.Identity;
    using Infrastructure.Common.Events;

    public class HotelDbContext : IdentityDbContext<User>, IDbContext
    {
        private readonly IEventDispatcher eventDispatcher = default!;
        private readonly Stack<object> savesChangesTracker;

        public HotelDbContext()
        {
            this.savesChangesTracker = new Stack<object>();
        }

        public HotelDbContext(
            DbContextOptions<HotelDbContext> options,
            IEventDispatcher eventDispatcher
            )
            : base(options)
        {
            this.eventDispatcher = eventDispatcher;

            this.savesChangesTracker = new Stack<object>();
        }


        public DbSet<ReservationData> Reservations { get; set; } = default!;

        public DbSet<RoomData> Rooms { get; set; } = default!;

        public DbSet<PaymentData> Payments { get; set; } = default!;

        public DbSet<RoomTypeData> RoomTypes { get; set; } = default!;

        public DbSet<PaymentTypeData> PaymentTypes { get; set; } = default!;

        public DbSet<SpecialOfferData> SpecialOffers { get; set; } = default!;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            this.savesChangesTracker.Push(new object());

            var entities = this.ChangeTracker
                .Entries<IEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entities)
            {
                var events = entity.Events.ToArray();

                entity.ClearEvents();

                foreach (var domainEvent in events)
                {
                    await this.eventDispatcher.Dispatch(domainEvent);
                }
            }

            this.savesChangesTracker.Pop();

            if (!this.savesChangesTracker.Any())
            {
                return await base.SaveChangesAsync(cancellationToken);
            }

            return 0;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
