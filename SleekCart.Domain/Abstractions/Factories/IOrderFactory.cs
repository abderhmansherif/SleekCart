
using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Order;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Factories
{
    public interface IOrderFactory
    {
        Order CreateDefault(OrderId OrderId, UserId userId, ShippingAddress shippingAddress);
        Order CreateWithItems(OrderId OrderId, UserId userId, ShippingAddress shippingAddress,
            List<OrderItem> items);
    }
}
