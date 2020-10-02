using Common.Application;
using Core.Domain.Hotel.Repositories.Reservations;
using FluentValidation;

namespace Core.Application.Hotel.Reservations.Commands.Common
{
    public class ReservationCommandValidator<TCommand> : AbstractValidator<ReservationCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public ReservationCommandValidator(IReservationDomainRepository reservationRepository)
        {
            //this.RuleFor(c => c.Manufacturer)
            //    .MinimumLength(MinNameLength)
            //    .MaximumLength(MaxNameLength)
            //    .NotEmpty();

            //this.RuleFor(c => c.Model)
            //    .MinimumLength(MinModelLength)
            //    .MaximumLength(MaxModelLength)
            //    .NotEmpty();

            //this.RuleFor(c => c.Category)
            //    .MustAsync(async (category, token) => await carAdRepository
            //        .GetCategory(category, token) != null)
            //    .WithMessage("'{PropertyName}' does not exist.");

            //this.RuleFor(c => c.ImageUrl)
            //    .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
            //    .WithMessage("'{PropertyName}' must be a valid url.")
            //    .NotEmpty();

            //this.RuleFor(c => c.PricePerDay)
            //    .InclusiveBetween(Zero, decimal.MaxValue);

            //this.RuleFor(c => c.NumberOfSeats)
            //    .InclusiveBetween(MinNumberOfSeats, MaxNumberOfSeats);

            //this.RuleFor(c => c.TransmissionType)
            //    .Must(Enumeration.HasValue<TransmissionType>)
            //    .WithMessage("'Transmission Type' is not valid.");
        }
    }
}
