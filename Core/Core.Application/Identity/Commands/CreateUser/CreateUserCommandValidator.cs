namespace Common.Application.Identity.Commands.CreateUser
{
    using FluentValidation;

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            //this.RuleFor(u => u.Email)
            //    .MinimumLength(MinEmailLength)
            //    .MaximumLength(MaxEmailLength)
            //    .EmailAddress()
            //    .NotEmpty();

            //this.RuleFor(u => u.Password)
            //    .MaximumLength(MaxNameLength)
            //    .NotEmpty();
        }
    }
}
