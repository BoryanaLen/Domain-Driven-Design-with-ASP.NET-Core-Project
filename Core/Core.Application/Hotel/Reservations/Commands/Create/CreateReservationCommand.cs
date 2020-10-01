namespace Core.Application.Hotel.Reservations.Commands.Create
{
    using Common;
    using MediatR;

    public class CreateReservationCommand : ReservationCommand<CreateReservationCommand>, IRequest<CreateReservationOutputModel>
    {
    }
}
