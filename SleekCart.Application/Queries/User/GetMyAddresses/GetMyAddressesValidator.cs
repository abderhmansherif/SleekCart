using FluentValidation;

namespace SleekCart.Application.Queries.User.GetMyAddresses;

public class GetMyAddressesValidator: AbstractValidator<GetMyAddressesQuery>
{
    public GetMyAddressesValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is Required");
    }
}
