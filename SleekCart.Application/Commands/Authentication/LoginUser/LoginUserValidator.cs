using FluentValidation;

namespace SleekCart.Application.Commands.Authentication.LoginUser;

public sealed class LoginUserValidator: AbstractValidator<LoginUserCommand>
{
    public LoginUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithErrorCode("Email is Required.")
            .EmailAddress().WithErrorCode("Not Valid Email");

        RuleFor(x => x.Password)
            .NotEmpty().WithErrorCode("Password is Required.")
            .MinimumLength(8).WithErrorCode("Password must be at least 8 characters.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one number.");
    }
}
