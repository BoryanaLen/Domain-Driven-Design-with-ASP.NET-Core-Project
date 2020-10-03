namespace Core.Infrastructure.Persistence.Models
{
    using AutoMapper;
    using Common.Application.Mapping;
    using Common.Domain.Models;
    using Core.Domain.Hotel.Models.SpecialOffers;

    internal class SpecialOfferData : Entity<int>
    {
        internal SpecialOfferData(string title, string content, string shortContent)
        {
            this.Title = title;
            this.Content = content;
            this.ShortContent = shortContent;
        }

        public string Title { get; set; } = default!;

        public string Content { get; set; } = default!;

        public string ShortContent { get; set; } = default!;
    }
}
