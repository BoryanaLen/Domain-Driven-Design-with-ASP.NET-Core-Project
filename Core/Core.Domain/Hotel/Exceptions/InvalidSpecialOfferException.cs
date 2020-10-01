namespace Core.Domain.Hotel.Exceptions
{
    using Common.Domain;

    public class InvalidSpecialOfferException : BaseDomainException
    {
        public InvalidSpecialOfferException()
        {
        }

        public InvalidSpecialOfferException(string error) => this.Error = error;
    }
}
