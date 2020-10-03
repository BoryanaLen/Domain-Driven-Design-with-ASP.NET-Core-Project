namespace Core.Infrastructure.Hotel.Configuration
{
    using Core.Domain.Hotel.Models.Customers;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.FirstName)
                .IsRequired();

            builder
                .Property(c => c.LastName)
                .IsRequired();

            builder
                .Property(c => c.UserId)
                .IsRequired();

            builder
                .Property(c => c.Email)
                .IsRequired();
        }
    }
}
