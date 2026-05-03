using FluentValidation;

namespace SleekCart.Application.Commands.Product.UpdateProductDetails;

public class UpdateProductDetailsValidator: AbstractValidator<UpdateProductDetailsCommand>
{
    public UpdateProductDetailsValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty().WithMessage("Product Name is Required.")
            .MaximumLength(150).WithMessage("Product name cannot be longer than 150 characters.");

        RuleFor(x => x.ProductDescription)
            .NotEmpty().WithMessage("Product Description is Required.")
            .MaximumLength(600).WithMessage("Product Description cannot be longer than 600 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Invalid Price.");
    }
}
