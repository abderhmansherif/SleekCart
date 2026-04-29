using FluentValidation;

namespace SleekCart.Application.Commands.User.DeleteUser;

public class DeleteUservalidator: AbstractValidator<DeleteUserCommand>
{
    public DeleteUservalidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User Id is Required.");
    }
}
