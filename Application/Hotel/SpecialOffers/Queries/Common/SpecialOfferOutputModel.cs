namespace Application.Administration.SpecialOffers.Queries.Common
{
    using Application.Common.Mapping;
    using AutoMapper;
    using Domain.Administration.Models.SpecialOffer;

    public class SpecialOfferOutputModel 
    {
        public int Id { get; private set; }

        public string Title { get; private set; } = default!;

        public string Content { get; private set; } = default!;

        public string ShortContent { get; private set; } = default!;

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<SpecialOffer, SpecialOfferOutputModel>();
    }
}
