using e_commerse.Domain.Abstractions.Repositories;
using FluentValidation;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;
using SleekCart.Domain.ValueObjects.Product;

namespace SleekCart.Application.Commands.Product.UpdateProductDetails;

public sealed class UpdateProductDetailsHandler: ICommandHandler<UpdateProductDetailsCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateProductDetailsCommand> _validator;

    public UpdateProductDetailsHandler(IProductRepository productRepository, IUnitOfWork unitOfWork,
                                    IValidator<UpdateProductDetailsCommand> validator)
    {
        this._productRepository = productRepository;
        this._unitOfWork = unitOfWork;
        this._validator = validator;
    }

    public async Task HandleAsync(UpdateProductDetailsCommand command, CancellationToken ct)
    {
        var result = _validator.Validate(command);

        if(!result.IsValid)
        {
            throw new ValidationFailedException(result.Errors);
        }
        
        var (productId, productName, productDes, price) = command;

        var product = await _productRepository.GetAsync(productId, ct);

        if(product is null)
        {
            throw new NotFoundProductException();
        }

        var newPrice = new Money(ammount: price, product.Price.Currency);
        var newName = new ProductName(productName);
        var newDescreption = new ProductDescription(productDes);

        product.UpdateDetails(newName, newDescreption, newPrice);

        await _productRepository.UpdateAsync(product, ct);
        await _unitOfWork.SaveChangesAsync();
    }
}
