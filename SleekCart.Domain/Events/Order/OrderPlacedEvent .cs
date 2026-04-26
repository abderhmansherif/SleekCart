using SleekCart.Domain.Abstractions.Domain;
using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Order;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Domain.Events.Order
{
    public record OrderPlacedEvent : IDomainEvent
    {
        public DateTime OccurredOn { get; }
        public UserId UserId { get; }
        public OrderId OrderId { get; }
        public IReadOnlyCollection<OrderItem> OrderItems { get; }

        public OrderPlacedEvent(UserId userId, OrderId orderId, 
            IReadOnlyCollection<OrderItem> orderItems)
        {
            UserId = userId;
            OrderId = orderId;
            OrderItems = orderItems;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
