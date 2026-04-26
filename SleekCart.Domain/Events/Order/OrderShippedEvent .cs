using SleekCart.Domain.Abstractions.Domain;
using SleekCart.Domain.ValueObjects.Order;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Domain.Events.Order
{
    public record OrderShippedEvent : IDomainEvent
    {
        public DateTime OccurredOn { get; }
        public UserId UserId { get; }
        public OrderId OrderId { get; }

        public OrderShippedEvent(UserId userId, OrderId orderId)
        {
            UserId = userId;
            OrderId = orderId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
