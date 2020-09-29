namespace Infrastructure.Common.Persistence.Configurations
{
    using Models.PaymentTypeData;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Domain.Hotel.Models.ModelConstants.Common;

    public class PaymentTypesConfiguration : IEntityTypeConfiguration<PaymentTypeData>
    {
        public void Configure(EntityTypeBuilder<PaymentTypeData> builder)
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
