namespace Application.Common.Mapping
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Application.Administration.SpecialOffers.Queries.All;
    using AutoMapper;
    using Domain.Administration.Models.SpecialOffer;

    public class MappingProfile : Profile
    {
        //public MappingProfile()
        //    => this.ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());

        public MappingProfile()
        {
            this.CreateMap<SpecialOffer, AllSpecialOfferOutputModel>();
 
           

            //this.CreateMap<Order, ViewModels.Orders.OrderDetailsViewModel>()
            //              .ForMember(x => x.Status, y => y.MapFrom(src => src.Status.GetDisplayName()))
            //              .ForMember(x => x.PaymentStatus, y => y.MapFrom(src => src.PaymentStatus.GetDisplayName()))
            //              .ForMember(x => x.PaymentType, y => y.MapFrom(src => src.PaymentType.GetDisplayName()));
        }
    }
}
