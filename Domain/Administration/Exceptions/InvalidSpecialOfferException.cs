namespace Domain.Administration.Exceptions
{
    using Common;

    class InvalidSpecialOfferException : BaseDomainException
    {
        public InvalidSpecialOfferException()
        {
        }

        public InvalidSpecialOfferException(string error) => this.Error = error;
    }
}
