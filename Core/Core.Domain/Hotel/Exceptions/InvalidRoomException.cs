namespace Core.Domain.Hotel.Exceptions
{
    using Common.Domain;

    public class InvalidRoomException : BaseDomainException
    {
        public InvalidRoomException()
        {
        }

        public InvalidRoomException(string error) => this.Error = error;
    }
}
