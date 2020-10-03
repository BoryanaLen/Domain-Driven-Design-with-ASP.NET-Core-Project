namespace Core.Infrastructure.Persistence.Models.SpecialOfferData
{
    using Common.Application.Mapping;
    using Core.Domain.Hotel.Models.SpecialOffers;

    public class SpecialOfferData :IMapTo<SpecialOffer>
    {
        public string Title { get; set; } = default!;

        public string Content { get; set; } = default!;

        public string ShortContent { get; set; } = default!;
    }
}
