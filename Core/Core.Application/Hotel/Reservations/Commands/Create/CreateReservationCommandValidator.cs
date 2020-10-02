namespace Core.Application.Hotel.Reservations.Commands.Create
{
    using Common;
    using Core.Domain.Hotel.Repositories.Reservations;
    using FluentValidation;

    class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationCommandValidator(IReservationDomainRepository reservationRepository)
           => this.Include(new ReservationCommandValidator<CreateReservationCommand>(reservationRepository));
    }
}
