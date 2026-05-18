using System.Windows.Input;
using e_commerse.Domain.Abstractions.Factories;
using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;
using SleekCart.Application.Services;
using SleekCart.Domain.Entities;

namespace SleekCart.Application.Commands.Order.PlaceOrder;

public sealed class PlaceOrderHandler: ICommandHandler<PlaceOrderCommand>
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderFactory _orderFactory;

    public PlaceOrderHandler(ICartRepository cartRepository, IProductRepository productRepository,
            IOrderRepository orderRepository, IUnitOfWork unitOfWork, IOrderFactory orderFactory)
    {
        this._cartRepository = cartRepository;
        this._productRepository = productRepository;
        this._orderRepository = orderRepository;
        this._unitOfWork = unitOfWork;
        this._orderFactory = orderFactory;
    }

    public async Task HandleAsync(PlaceOrderCommand command, CancellationToken ct)
    {
        var cart = await _cartRepository.GetAsync(command.CartId, ct);

        if(cart is null)
        {
            throw new NotFoundCartException();
        }
        
        List<OrderItem> orderItems = new();
        var OrderId = Guid.NewGuid();
        var productIds = cart.Items.Select(x => x.ProductId).ToList();
        
        var products = await _productRepository.GetByIdsAsync(productIds, ct);

        foreach(var item in cart.Items)
        {
            var product = products.FirstOrDefault(x => x.Id == item.ProductId);

            if(product is null)
            {
                throw new NotFoundProductException();
            }

            product.ReserveStock(
                cartId: command.CartId,
                quantity: item.Quantity,
                TimeSpan.FromMinutes(15)
            );

            await _productRepository.UpdateAsync(product, ct);

            orderItems.Add(new OrderItem(
                orderId: OrderId,
                productId: product.Id,
                quantity: item.Quantity,
                price: item.Price
            ));
        }

        var newOrder = _orderFactory.CreateWithItems(
            OrderId: OrderId, 
            userId: command.UserId, 
            shippingAddress: command.ShippingAddress, 
            items: orderItems);

        await _orderRepository.InsertAsync(newOrder, ct);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}
