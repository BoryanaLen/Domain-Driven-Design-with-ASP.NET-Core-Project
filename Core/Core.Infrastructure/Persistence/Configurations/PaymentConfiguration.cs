namespace Core.Infrastructure.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models.PaymentData;

    public class PaymentConfiguration : IEntityTypeConfiguration<PaymentData>
    {
        public void Configure(EntityTypeBuilder<PaymentData> builder)
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
