using System.Data;
using FluentValidation;

namespace SleekCart.Application.Commands.User.DeleteAddress;

public class DeleteAddressValidator: AbstractValidator<DeleteAddressCommand>
{
    public DeleteAddressValidator()
    {
        RuleFor(x => x.AddressId)
            .NotEmpty().WithMessage("Address Id is Required.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User Id is Required.");
    }
}
