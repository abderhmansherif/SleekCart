using e_commerse.Domain.Abstractions.Repositories;
using FluentValidation;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;
using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Product;

namespace SleekCart.Application.Commands.Cart.AddItemToCart;

public sealed class AddItemToCartHandler: ICommandHandler<AddItemToCartCommand>
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<AddItemToCartCommand> _validator;

    public AddItemToCartHandler(ICartRepository cartRepository, IProductRepository productRepository,
                            IUnitOfWork unitOfWork, IValidator<AddItemToCartCommand> validator)
    {
        this._cartRepository = cartRepository;
        this._productRepository = productRepository;
        this._unitOfWork = unitOfWork;
        this._validator = validator;
    }

    public async Task HandleAsync(AddItemToCartCommand command, CancellationToken ct)
    {
        var result = await _validator.ValidateAsync(command);

        if(!result.IsValid)
        {
            throw new ValidationFailedException(result.Errors);
        }
        var (productId, cartId, quantity, money) = command;

        var cart = await _cartRepository.GetAsync(command.CartId, ct);

        if(cart is null)
        {
            throw new NotFoundCartException();
        }

        var product = await _productRepository.GetAsync(command.ProductId, ct);

        if(product is null)
        {
            throw new NotFoundProductException();
        }

        product.ReserveStock(cartId: cartId, quantity: quantity, TimeSpan.FromMinutes(15));

        //if passed that means the product is availabe with needed quantity

        cart.AddItem(new CartItem(
            cartId: cartId,
            productId: productId,
            price: new Money(ammount: money.Amount, currency: money.Currency),
            quantity: quantity
        ));

        await _cartRepository.UpdateAsync(cart, ct);
        await _productRepository.UpdateAsync(product, ct);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}
