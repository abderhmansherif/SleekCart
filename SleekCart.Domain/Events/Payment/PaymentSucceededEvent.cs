
using SleekCart.Domain.Abstractions.Domain;
using SleekCart.Domain.ValueObjects.Order;
using SleekCart.Domain.ValueObjects.Payment;
using SleekCart.Domain.ValueObjects.Product;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Domain.Events.Payment
{
    public record PaymentSucceededEvent : IDomainEvent
    {
        public DateTime OccurredOn { get; }
        public UserId UserId { get; }
        public OrderId OrderId { get; }
        public PaymentId PaymentId { get; }
        public Money Amount { get; }

        public PaymentSucceededEvent(UserId userId, OrderId orderId, 
            PaymentId paymentId, Money amount)
        {
            UserId = userId;
            OrderId = orderId;
            PaymentId = paymentId;
            Amount = amount;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
