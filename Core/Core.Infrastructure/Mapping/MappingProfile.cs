namespace Common.Application.Mapping
{
    using System;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;
    using Core.Application.Hotel.SpecialOffers.Queries.All;
    using Core.Domain.Hotel.Models.SpecialOffers;
    using Core.Infrastructure.Persistence.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SpecialOfferData, SpecialOffer>();

            CreateMap<SpecialOffer, AllSpecialOfferOutputModel>();

            CreateMap<SpecialOfferData, AllSpecialOfferOutputModel>();
        }
    }
}
