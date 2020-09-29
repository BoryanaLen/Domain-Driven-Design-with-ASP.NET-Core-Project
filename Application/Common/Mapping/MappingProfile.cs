namespace Application.Common.Mapping
{
    using Application.Hotel.SpecialOffers.Queries.All;
    using AutoMapper;
    using Domain.Administration.Models.SpecialOffer;

    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
           // this.CreateMap<SpecialOffer, AllSpecialOfferOutputModel>();
        }
    }
}
