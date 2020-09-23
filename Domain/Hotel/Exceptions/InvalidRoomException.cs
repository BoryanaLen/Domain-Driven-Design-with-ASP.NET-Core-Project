namespace Domain.Hotel.Exceptions
{
    using Common;

    public class InvalidRoomException : BaseDomainException
    {
        public InvalidRoomException()
        {
        }

        public InvalidRoomException(string error) => this.Error = error;
    }
}
