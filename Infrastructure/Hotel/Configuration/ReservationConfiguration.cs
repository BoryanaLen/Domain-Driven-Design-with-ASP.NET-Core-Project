namespace Infrastructure.Hotel.Configuration
{
    using Domain.Hotel.Models.Reservations;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.StartDate)
                .IsRequired();

            builder
                .Property(c => c.EndDate)
                .IsRequired();

            builder
                .Property(c => c.Adults)
                .IsRequired();

            builder
                .Property(c => c.Kids)
                .IsRequired();

            builder
                .Property(c => c.PricePerDay)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
               .Property(c => c.AdvancedPayment)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

            builder
               .Property(c => c.IsPaid)
               .IsRequired();


            builder
                .HasMany(d => d.Payments)
                .WithOne();


            builder
               .HasMany(d => d.Rooms)
               .WithOne();

            builder
                .HasOne(c => c.Customer)
                .WithMany()
                .HasForeignKey("CustomerId")
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(c => c.PaymentType)
               .WithMany();
        }
    }
}
