using FluentValidation;
using SleekCart.ApplicationCommands.Authentication.RegisterUser;

namespace SleekCart.Application.Commands.Authentication.RegisterUser;

public sealed class RegisterUserValidator: AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithErrorCode("Email is Required.")
            .EmailAddress().WithErrorCode("Not Valid Email");

        RuleFor(x => x.FullName)
            .NotEmpty().WithErrorCode("FullName is Required.")
            .MaximumLength(100).WithMessage("FullName is too long.");

        RuleFor(x => x.Password)
            .NotEmpty().WithErrorCode("Password is Required.")
            .MinimumLength(8).WithErrorCode("Password must be at least 8 characters.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one number.");
            
    }
}
