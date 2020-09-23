namespace Infrastructure.Administration.Configuration
{
    using Domain.Administration.Models.SpecialOffer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Domain.Administration.Models.ModelConstants.SpecialOffer;

    public class SpecialOfferConfiguration : IEntityTypeConfiguration<SpecialOffer>
    {
        public void Configure(EntityTypeBuilder<SpecialOffer> builder)
        {
            builder
               .HasKey(c => c.Id);

            builder
                .Property(c => c.Title)
                .HasMaxLength(TitleMaxLength)
                .IsRequired();

            builder
                .Property(c => c.Content)
                 .HasMaxLength(ContentMaxLength)
                 .IsRequired();

            builder
                .Property(c => c.ShortContent)
                 .HasMaxLength(ShortContentMaxLength)
                 .IsRequired();
        }
    }
}
