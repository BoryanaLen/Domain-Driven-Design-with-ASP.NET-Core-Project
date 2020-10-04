namespace Core.Infrastructure.Persistence
{
    using Common.Domain.Models;
    using Common.Infrastructure.Events;
    using Core.Domain.Administration.Models.Payments;
    using Core.Domain.Hotel.Models.Customers;
    using Core.Domain.Hotel.Models.Reservations;
    using Core.Infrastructure.Administration;
    using Core.Infrastructure.Hotel;
    using Core.Infrastructure.Persistence.Models;
    using Infrastructure.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    public class HotelSystemDbContext : IdentityDbContext<User>,
        IHotelDbContext, IAdministrationDbContext
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

        public DbSet<SpecialOfferData> SpecialOffers { get; set; } = default!;

        public DbSet<PaymentData> Payments { get; set; } = default!;

        public DbSet<Room> Rooms { get; set; } = default!;

        public DbSet<RoomType> RoomTypes { get; set; } = default!;

        public DbSet<Customer> Customers { get; set; } = default!;

        public DbSet<PaymentType> PaymentTypes { get; set; } = default!;

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
