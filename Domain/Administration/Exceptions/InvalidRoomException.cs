namespace Domain.Administration.Exceptions
{
    using Common;
    class InvalidRoomException : BaseDomainException
    {
        public InvalidRoomException()
        {
        }

        public InvalidRoomException(string error) => this.Error = error;
    }
}
