namespace Infrastructure.Common.Persistence.Configurations
{
    using Models.RoomTypeData;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Domain.Hotel.Models.ModelConstants.RoomType;
    using static Domain.Hotel.Models.ModelConstants.Common;

    public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomTypeData>
    {
        public void Configure(EntityTypeBuilder<RoomTypeData> builder)
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
