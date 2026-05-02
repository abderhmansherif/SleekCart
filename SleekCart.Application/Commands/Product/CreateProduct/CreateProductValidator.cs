using FluentValidation;

namespace SleekCart.Application.Commands.Product.CreateProduct;

public class CreateProductValidator: AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty().WithMessage("Product Name is Required.")
            .MaximumLength(150).WithMessage("Product name cannot be longer than 150 characters.");

        RuleFor(x => x.ProductDescription)
            .NotEmpty().WithMessage("Product Description is Required.")
            .MaximumLength(600).WithMessage("Product Description cannot be longer than 600 characters.");

        RuleFor(x => x.StockQuantity)
            .GreaterThan(0).WithMessage("Invalid Stock Quantity.");

        RuleFor(x => x.Price.Amount)
            .GreaterThan(0).WithMessage("Invalid Price.");

        RuleFor(x => x.Price.Currency)
            .MaximumLength(3);

        RuleFor(x => x.Images)
            .NotNull()
            .NotEmpty().WithMessage("At least one image is required.")
            .Must(imgs => imgs.Count <= 10).WithMessage("Maximum 10 images allowed.");


        RuleForEach(x => x.Images).ChildRules(image =>
        {
           image.RuleFor(x => x.FileName)
                    .NotEmpty();

            image.RuleFor(x => x.ContentType)
                .NotEmpty()
                .Must(ct => ct.StartsWith("image/")).WithMessage("File Must be an image"); 

            image.RuleFor(x => x.Stream)
                .NotEmpty()
                .Must(s => s.Length > 5 * 1024 * 1024).WithMessage("Image must be less than 5MB");
        });
    }
}
