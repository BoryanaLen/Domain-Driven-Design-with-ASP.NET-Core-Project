namespace Core.Infrastructure.Persistence.Configurations
{
    using Core.Infrastructure.Persistence.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ReservationRoomDataConfigurations : IEntityTypeConfiguration<ReservationRoomData>
    {
        public void Configure(EntityTypeBuilder<ReservationRoomData> builder)
        {
            builder
                .HasKey(c => c.Id);

        }
    }
}
