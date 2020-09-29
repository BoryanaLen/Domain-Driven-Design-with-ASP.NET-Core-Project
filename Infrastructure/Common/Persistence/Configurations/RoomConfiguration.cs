namespace Infrastructure.Common.Persistence.Configurations
{
    using Models.RoomData;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Domain.Hotel.Models.ModelConstants.Room;

    public class RoomConfiguration : IEntityTypeConfiguration<RoomData>
    {
        public void Configure(EntityTypeBuilder<RoomData> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.RoomNumber)
                .HasMaxLength(MaxRoomNumberLength)
                .IsRequired();

            builder
                .Property(c => c.Description)
                .HasMaxLength(MaxDescriptionLength)
                .IsRequired();

            builder
                .HasOne(c => c.RoomType)
                .WithMany()
                .HasForeignKey("RoomTypeId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
