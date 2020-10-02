namespace Core.Infrastructure.Persistence
{
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Infrastructure.Identity;
    using Common.Infrastructure.Events;
    using Models.RoomData;
    using Models.PaymentData;
    using Models.ReservationData;
    using Models.RoomTypeData;
    using Models.SpecialOfferData;
    using Models.PaymentTypeData;
    using Models.CustomerData;
    using Common.Domain.Models;
    using Core.Infrastructure.Persistence.Models;

    public class HotelSystemDbContext : IdentityDbContext<User>, IDbContext
    {
        private readonly IEventDispatcher eventDispatcher = default!;
        private readonly Stack<object> savesChangesTracker;


        public HotelSystemDbContext(
            DbContextOptions<HotelSystemDbContext> options,
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

        public DbSet<CustomerData> Customers { get; set; } = default!;

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
