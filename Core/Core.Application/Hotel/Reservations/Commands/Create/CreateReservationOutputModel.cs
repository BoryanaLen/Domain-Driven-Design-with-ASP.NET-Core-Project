namespace Core.Application.Hotel.Reservations.Commands.Create
{
    public class CreateReservationOutputModel
    {
        public CreateReservationOutputModel(int reservationId)
           => this.reservationId = reservationId;

        public int reservationId { get; }
    }
}
