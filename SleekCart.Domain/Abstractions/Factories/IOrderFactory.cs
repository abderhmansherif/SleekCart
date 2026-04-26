using e_commerse.Domain.Entities;
using e_commerse.Domain.ValueObjects.Order;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Factories
{
    public interface IOrderFactory
    {
        Order CreateDefault(OrderId id, UserId userId, ShippingAddress shippingAddress);
        Order CreateWithItems(OrderId id, UserId userId, ShippingAddress shippingAddress,
            List<OrderItem> items);
    }
}
