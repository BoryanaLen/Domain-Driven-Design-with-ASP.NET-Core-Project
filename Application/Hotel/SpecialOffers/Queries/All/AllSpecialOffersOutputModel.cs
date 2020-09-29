namespace Application.Hotel.SpecialOffers.Queries.All
{
    using Application.Common;
    using Domain.Hotel.Models.SpecialOffers;
    using System.Collections.Generic;

    public class AllSpecialOffersOutputModel : PagedListViewModel
    {
        public IEnumerable<AllSpecialOfferOutputModel>? SpecialOffers { get; set; }
    }
}
