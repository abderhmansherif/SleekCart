using SleekCart.Domain.Abstractions.Domain;
using SleekCart.Domain.ValueObjects.Order;
using SleekCart.Domain.ValueObjects.User;
using SleekCart.Shared.Abstractions.Events;

namespace SleekCart.Domain.Events.Order;

public sealed record OrderRefundRequestedEvent : IDomainEvent
{
    public DateTime OccurredOn {get; }
    public UserId UserId  { get; }
    public OrderId OrderId { get; }

    public OrderRefundRequestedEvent(UserId userId, OrderId orderId)
    {
        this.UserId = userId;
        this.OrderId = orderId;
        OccurredOn = DateTime.UtcNow;
    }
}