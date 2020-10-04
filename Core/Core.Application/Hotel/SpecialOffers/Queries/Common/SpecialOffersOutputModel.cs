namespace Core.Application.Hotel.Application.Hotel.SpecialOffers.Queries.Common
{
    using System.Collections.Generic;

    public abstract class SpecialOffersOutputModel<TSpecialOfferOutputModel>
    {
        internal SpecialOffersOutputModel(
            IEnumerable<TSpecialOfferOutputModel> specialOffers)
        {
            this.SpecialOffers = specialOffers;
        }

        public IEnumerable<TSpecialOfferOutputModel> SpecialOffers { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}
