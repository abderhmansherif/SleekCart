using e_commerse.Domain.Abstractions.Domain;
using e_commerse.Domain.ValueObjects.Order;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Events.Order
{
    public record OrderDeliveredEvent : IDomainEvent
    {
        public OrderId OrderId { get; }
        public UserId UserId { get; }
        public DateTime OccurredOn { get; }
        public OrderDeliveredEvent(OrderId orderId, UserId userId)
        {
            OrderId = orderId;
            UserId = userId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
