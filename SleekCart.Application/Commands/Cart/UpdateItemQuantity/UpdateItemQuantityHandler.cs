using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;
using SleekCart.Domain.Entities;

namespace SleekCart.Application.Commands.Cart.UpdateItemQuantity;

public sealed class UpdateItemQuantityHandler: ICommandHandler<UpdateItemQuantityCommand>
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateItemQuantityHandler(ICartRepository cartRepository, IProductRepository productRepository, 
                    IUnitOfWork unitOfWork)
    {
        this._cartRepository = cartRepository;
        this._productRepository = productRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(UpdateItemQuantityCommand command, CancellationToken ct)
    {
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

        if(command.NewQuantity <= 0)
        {
            cart.RemoveItem(product.Id);
            product.ReleaseReservation(cart.Id);
        }
        else
        {
            product.ReserveStock(cartId: cart.Id, quantity: command.NewQuantity, TimeSpan.FromMinutes(15));

            cart.AddItem(new CartItem(
                cartId: cart.Id,
                productId: product.Id,
                quantity: command.NewQuantity,
                price: product.Price
            ));
        }

        await _cartRepository.UpdateAsync(cart, ct);
        await _productRepository.UpdateAsync(product, ct);
        await _unitOfWork.SaveChangesAsync();
    }
}
