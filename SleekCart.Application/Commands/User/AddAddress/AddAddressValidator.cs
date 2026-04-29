using System.Data;
using FluentValidation;

namespace SleekCart.Application.Commands.User.AddAddress;

public class AddAddressValidator: AbstractValidator<AddAddressCommand>
{
    public AddAddressValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Known User Address.");

        RuleFor(x => x.City)
            .NotEmpty().WithErrorCode("City is Required.")
            .MaximumLength(100).WithErrorCode("City must be less than 100 letter.");

        RuleFor(x => x.Street)
            .NotEmpty().WithErrorCode("Street is Required.")
            .MaximumLength(100).WithErrorCode("Street must be less than 100 letter.");

        RuleFor(x => x.Building)
            .NotEmpty().WithErrorCode("Building is Required.")
            .MaximumLength(100).WithErrorCode("Building must be less than 100 letter.");

        RuleFor(x => x.Note)
            .NotEmpty().WithErrorCode("Note is Required.")
            .MaximumLength(200).WithErrorCode("Note must be less than 200 letter.");
    }
}
