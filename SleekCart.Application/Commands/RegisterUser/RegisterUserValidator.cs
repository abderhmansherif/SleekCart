using FluentValidation;
using SleekCart.Application.RegisterUser;

namespace SleekCart.Application.Commands.RegisterUser;

public sealed class RegisterUserValidator: AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithErrorCode("Email is Required.")
            .EmailAddress().WithErrorCode("Not Valid Email");

        RuleFor(x => x.FullName)
            .NotEmpty().WithErrorCode("FullName is Required")
            .MaximumLength(100).WithMessage("FullName is too long");
    }
}
