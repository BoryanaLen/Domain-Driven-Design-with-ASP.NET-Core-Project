namespace Core.Domain.Hotel.Exceptions
{
    using Common.Domain;

    public class InvalidReservationException : BaseDomainException
    {
        public InvalidReservationException()
        {
        }

        public InvalidReservationException(string error) => this.Error = error;
    }
}
