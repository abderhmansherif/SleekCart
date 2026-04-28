using FluentValidation;

namespace SleekCart.Application.Commands.UpdateProfile;

public class UpdateProfileValidator: AbstractValidator<UpdateProfileCommand>
{
    public UpdateProfileValidator()
    {
        RuleFor(x => x.NewFullName)
            .NotEmpty().WithMessage("FullName is Required.");
    }
}
