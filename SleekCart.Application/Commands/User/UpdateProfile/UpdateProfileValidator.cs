using FluentValidation;

namespace SleekCart.Application.Commands.User.UpdateProfile;

public class UpdateProfileValidator: AbstractValidator<UpdateProfileCommand>
{
    public UpdateProfileValidator()
    {
        RuleFor(x => x.NewFullName)
            .NotEmpty().WithMessage("FullName is Required.");
    }
}
