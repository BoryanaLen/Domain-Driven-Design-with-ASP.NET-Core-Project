namespace Core.Application.Hotel.Application.Hotel.SpecialOffers.Queries.Common
{
    using AutoMapper;

    public class SpecialOfferOutputModel 
    {
        public int Id { get; private set; }

        public string Title { get; private set; } = default!;

        public string Content { get; private set; } = default!;

        public string ShortContent { get; private set; } = default!;

        //public virtual void Mapping(Profile mapper)
        //    => mapper
        //        .CreateMap<SpecialOffer, SpecialOfferOutputModel>();
    }
}
