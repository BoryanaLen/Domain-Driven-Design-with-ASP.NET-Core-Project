namespace Hotel.Infrastructure.Hotel.Configuration
{

    using Domain.Hotel.Models.Reservations;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Domain.Hotel.Models.ModelConstants.Room;
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.DateOfPayment)
                .IsRequired();

            builder
                .Property(c => c.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .HasOne(p => p.PaymentType)
                .WithMany();
        }
    }
}
