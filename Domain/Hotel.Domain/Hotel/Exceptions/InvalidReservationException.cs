namespace Hotel.Domain.Hotel.Exceptions
{
    using Common;

    public class InvalidReservationException : BaseDomainException
    {
        public InvalidReservationException()
        {
        }

        public InvalidReservationException(string error) => this.Error = error;
    }
}
