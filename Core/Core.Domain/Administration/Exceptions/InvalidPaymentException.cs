namespace Core.Domain.Administration.Exceptions
{
    using Common.Domain;
    public class InvalidPaymentException : BaseDomainException
    {
        public InvalidPaymentException()
        {
        }

        public InvalidPaymentException(string error) => this.Error = error;
    }
}
