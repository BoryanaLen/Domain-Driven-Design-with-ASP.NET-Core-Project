namespace Domain.Hotel.Exceptions
{
    using Common;

    public class InvalidSpecialOfferException : BaseDomainException
    {
        public InvalidSpecialOfferException()
        {
        }

        public InvalidSpecialOfferException(string error) => this.Error = error;
    }
}
