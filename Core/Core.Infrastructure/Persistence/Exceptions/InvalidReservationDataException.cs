namespace Core.Infrastructure.Persistence.Exceptions
{
    using Common.Domain;

    public class InvalidReservationDataException : BaseDomainException
    {
        public InvalidReservationDataException()
        {
        }

        public InvalidReservationDataException(string error) => this.Error = error;
    }
}
