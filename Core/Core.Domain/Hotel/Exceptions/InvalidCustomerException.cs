namespace Core.Domain.Hotel.Exceptions
{
    using Common.Domain;

    public class InvalidCustomerException: BaseDomainException
    {
        public InvalidCustomerException()
        {
        }

        public InvalidCustomerException(string error) => this.Error = error;
    }
}
