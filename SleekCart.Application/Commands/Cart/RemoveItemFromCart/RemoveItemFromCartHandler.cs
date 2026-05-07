using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;

namespace SleekCart.Application.Commands.Cart.RemoveItemFromCart;

public sealed class RemoveItemFromCartHandler: ICommandHandler<RemoveItemFromCartCommand>
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveItemFromCartHandler(ICartRepository cartRepository, IProductRepository productRepository,
                    IUnitOfWork unitOfWork)
    {
        this._cartRepository = cartRepository;
        this._productRepository = productRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(RemoveItemFromCartCommand command, CancellationToken ct)
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

        cart.RemoveItem(product.Id);
        product.ReleaseReservation(cart.Id);

        await _cartRepository.UpdateAsync(cart, ct);
        await _productRepository.UpdateAsync(product, ct);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}
