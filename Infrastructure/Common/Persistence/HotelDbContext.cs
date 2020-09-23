namespace Infrastructure.Common.Persistence
{
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common.Models;
    using Events;
    using Domain.Hotel.Models.Reservations;
    using Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Infrastructure.Administration;
    using Infrastructure.Hotel;
    using Domain.Hotel.Models.Rooms;
    using Domain.Administration.Models.SpecialOffer;

    public class HotelDbContext : IdentityDbContext<User>,
        IAdministrationDbContext,
        IHotelDbContext
    {
        private readonly IEventDispatcher eventDispatcher;
        private bool eventsDispatched;

        public HotelDbContext(
            DbContextOptions<HotelDbContext> options,
            IEventDispatcher eventDispatcher)
            : base(options)
        {
            this.eventDispatcher = eventDispatcher;

            this.eventsDispatched = false;
        }

        public DbSet<Reservation> Reservations { get; set; } = default!;

        public DbSet<Room> Rooms { get; set; } = default!;

        public DbSet<Payment> Payments { get; set; } = default!;

        public DbSet<RoomType> RoomTypes { get; set; } = default!;

        public DbSet<PaymentType> PaymentTypes { get; set; } = default!;

        public DbSet<SpecialOffer> SpecialOffers { get; set; } = default!;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entriesModified = 0;

            if (!this.eventsDispatched)
            {
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

                this.eventsDispatched = true;

                entriesModified = await base.SaveChangesAsync(cancellationToken);
            }

            return entriesModified;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
