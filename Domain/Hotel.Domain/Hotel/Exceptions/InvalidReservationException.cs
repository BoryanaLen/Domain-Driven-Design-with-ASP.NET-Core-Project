using Hotel.Domain.Common;

namespace Hotel.Domain.Hotel.Exceptions
{
    public class InvalidReservationException : BaseDomainException
    {
        public InvalidReservationException()
        {
        }

        public InvalidReservationException(string error) => this.Error = error;
    }
}
