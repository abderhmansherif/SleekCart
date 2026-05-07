using FluentValidation;

namespace SleekCart.Application.Commands.Cart.AddItemToCart;

public class AddItemToCartValidator: AbstractValidator<AddItemToCartCommand>
{
    public AddItemToCartValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("Product Id is Required.");

        RuleFor(x => x.CartId)
            .NotEmpty().WithMessage("Cart Id is Required.");

        RuleFor(x => x.Quantity)
            .NotEmpty()
            .GreaterThan(0).WithMessage("Invalid Quantity.");

        RuleFor(x => x.money)
            .NotNull()
            .ChildRules(m =>
            {
               m.RuleFor(m => m.Currency)
                    .NotEmpty()
                    .MaximumLength(3).WithMessage("Invalid Currency Format.");

               m.RuleFor(m => m.Amount)
                    .GreaterThan(0);
            });
    }
}
