using FluentValidation;

namespace SleekCart.Application.Commands.Authentication.RefreshToken;

public class RefreshTokenValidator: AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenValidator()
    {
        RuleFor(x => x.AccessToken)
            .NotEmpty().WithErrorCode("AccessToken is Required.");

        RuleFor(x => x.RefreshToken)
            .NotEmpty().WithErrorCode("RefreshToken is Required.");
    }
}
