namespace Application.Administration.SpecialOffers.Handlers
{
    using System.Threading.Tasks;
    using Common;
    using Domain.Administration.Events.SpecialOffer;
    public class SpecialOfferAddedEventHandler: IEventHandler<SpecialOfferAddedEvent>
    {
        private readonly ISpecialOfferRepository specialOffers;

        public SpecialOfferAddedEventHandler(ISpecialOfferRepository specialOffers)
            => this.specialOffers = specialOffers;

        //public Task Handle(SpecialOfferAddedEvent domainEvent)
        //    => this.specialOffers.IncrementSpecialOffers();
    }
}
