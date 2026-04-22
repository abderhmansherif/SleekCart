using e_commerse.Domain.Abstractions.Domain;
using e_commerse.Domain.Entities;
using e_commerse.Domain.ValueObjects.Order;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Events.Order
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
