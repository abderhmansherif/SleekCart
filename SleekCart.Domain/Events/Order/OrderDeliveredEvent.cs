using SleekCart.Domain.Abstractions.Domain;
using SleekCart.Domain.ValueObjects.Order;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Domain.Events.Order
{
    public record OrderDeliveredEvent : IDomainEvent
    {
        public OrderId OrderId { get; }
        public UserId UserId { get; }
        public DateTime OccurredOn { get; }
        public OrderDeliveredEvent(UserId userId, OrderId orderId)
        {
            OrderId = orderId;
            UserId = userId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
