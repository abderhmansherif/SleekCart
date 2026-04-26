
using e_commerse.Domain.Abstractions.Factories;
using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Order;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Factories
{
    public class OrderFactory : IOrderFactory
    {
        public Order CreateDefault(OrderId id, UserId userId, ShippingAddress shippingAddress)
            => new Order(id, userId, shippingAddress);

        public Order CreateWithItems(OrderId id, UserId userId, ShippingAddress shippingAddress, List<OrderItem> items)
            => new Order(id, userId, shippingAddress, items);
    }
}
