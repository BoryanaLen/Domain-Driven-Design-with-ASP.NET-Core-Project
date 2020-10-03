namespace Core.Infrastructure.Hotel.Configurations
{
    using Core.Domain.Hotel.Models.Reservations;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static ModelConstants.RoomType;
    using static ModelConstants.Common;

    public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            builder
                .Property(c => c.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .Property(c => c.CapacityAdults)
                .IsRequired();

            builder
                .Property(c => c.CapacityKids)
                .IsRequired();

            builder
                .Property(c => c.Image)
                .IsRequired();

            builder
                .Property(c => c.Description)
                .HasMaxLength(MaxDescriptionLength)
                .IsRequired();
        }
    }
}
