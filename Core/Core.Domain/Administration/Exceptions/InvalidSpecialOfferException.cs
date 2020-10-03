namespace Core.Domain.Administration.Exceptions
{
    using Common.Domain;

    class InvalidSpecialOfferException: BaseDomainException
    {
        public InvalidSpecialOfferException()
        {
        }

        public InvalidSpecialOfferException(string error) => this.Error = error;
    }
}
