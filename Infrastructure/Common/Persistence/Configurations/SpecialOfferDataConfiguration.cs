﻿namespace Infrastructure.Common.Persistence.Configurations
{
    using Models.SpecialOfferData;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Domain.Administration.Models.ModelConstants.SpecialOffer;

    public class SpecialOfferDataConfiguration : IEntityTypeConfiguration<SpecialOfferData>
    {
        public void Configure(EntityTypeBuilder<SpecialOfferData> builder)
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