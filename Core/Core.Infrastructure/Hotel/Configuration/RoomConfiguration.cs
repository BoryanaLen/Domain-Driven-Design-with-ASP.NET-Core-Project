namespace Core.Infrastructure.Hotel.Configurations
{
    using Core.Domain.Hotel.Models.Reservations;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static ModelConstants.Room;
   
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
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
