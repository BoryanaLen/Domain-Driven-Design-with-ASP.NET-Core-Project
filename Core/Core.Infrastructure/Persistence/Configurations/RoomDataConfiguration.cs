namespace Core.Infrastructure.Hotel.Configurations
{
    using Core.Domain.Hotel.Models.Reservations;
    using Core.Infrastructure.Persistence.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static ModelConstants.Room;
   
    public class RoomDataConfiguration : IEntityTypeConfiguration<RoomData>
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
