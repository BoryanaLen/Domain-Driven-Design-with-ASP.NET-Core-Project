namespace Application.Hotel.SpecialOffers.Queries.All
{
    using Application.Common.Mapping;
    using AutoMapper;
    using Domain.Hotel.Models.SpecialOffers;

    public class AllSpecialOfferOutputModel 
    {
        public int Id { get;  set; }

        public string Title { get; set; } = default!;

        public string Content { get; set; } = default!;

        public string ShortContent { get;  set; } = default!;
    }
}
