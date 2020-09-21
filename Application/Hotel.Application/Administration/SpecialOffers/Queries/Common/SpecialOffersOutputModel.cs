namespace Hotel.Application.Administration.SpecialOffers.Queries.Common
{
    using System.Collections.Generic;

    public abstract class SpecialOffersOutputModel<TSpecialOfferOutputModel>
    {
        internal SpecialOffersOutputModel(
            IEnumerable<TSpecialOfferOutputModel> specialOffers,
            int page,
            int totalPages)
        {
            this.SpecialOffers = specialOffers;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<TSpecialOfferOutputModel> SpecialOffers { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}
