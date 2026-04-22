using e_commerse.Domain.Abstractions.Domain;
using e_commerse.Domain.ValueObjects.Order;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Events.Order
{
    public record OrderConfirmedEvent : IDomainEvent
    {
        public DateTime OccurredOn { get; }
        public UserId UserId { get; }
        public OrderId OrderId { get; }

        public OrderConfirmedEvent(UserId userId, OrderId orderId)
        {
            UserId = userId;
            OrderId = orderId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
