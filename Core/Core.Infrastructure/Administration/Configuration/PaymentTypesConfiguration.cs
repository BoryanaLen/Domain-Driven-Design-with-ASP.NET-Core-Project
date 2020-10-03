namespace Core.Infrastructure.Administration.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Core.Domain.Administration.Models.Payments;

    using static ModelConstants.Common;

    public class PaymentTypesConfiguration : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();
        }
    }
}
