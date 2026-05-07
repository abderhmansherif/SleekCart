using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;

namespace SleekCart.Application.Commands.Cart.ClearCart;

public sealed class ClearCartHandler: ICommandHandler<ClearCartCommand>
{
    private readonly ICartRepository _cartRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;

    public ClearCartHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork, 
                    IProductRepository productRepository)
    {
        this._cartRepository = cartRepository;
        this._unitOfWork = unitOfWork;
        this._productRepository = productRepository;
    }

    public async Task HandleAsync(ClearCartCommand command, CancellationToken ct)
    {
        var cart = await _cartRepository.GetAsync(command.CartId, ct);

        if(cart is null)
        {
            throw new NotFoundCartException();
        }

        foreach (var item in cart.Items)
        {
            var product = await _productRepository.GetAsync(item.ProductId, ct);

            if(product is null)
            {
                throw new NotFoundProductException();
            }

            product.ReleaseReservation(cart.Id);
        }

        cart.ClearCart();

        await _cartRepository.UpdateAsync(cart, ct);
        await _unitOfWork.SaveChangesAsync();
    }
}
