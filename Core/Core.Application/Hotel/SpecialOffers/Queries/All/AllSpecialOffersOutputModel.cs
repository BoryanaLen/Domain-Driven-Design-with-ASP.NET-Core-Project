namespace Core.Application.Hotel.SpecialOffers.Queries.All
{
    using global::Common.Application;
    using System.Collections.Generic;

    public class AllSpecialOffersOutputModel : PagedListViewModel
    {
        public IEnumerable<AllSpecialOfferOutputModel>? SpecialOffers { get; set; }
    }
}
