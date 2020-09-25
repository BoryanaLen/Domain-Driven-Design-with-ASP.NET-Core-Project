namespace Application.Administration.SpecialOffers.Queries.All
{
    using System.Collections.Generic;

    public class AllSpecialOffersOutputModel 
    {
        public IEnumerable<AllSpecialOfferOutputModel>? SpecialOffers { get; set; }
    }
}
