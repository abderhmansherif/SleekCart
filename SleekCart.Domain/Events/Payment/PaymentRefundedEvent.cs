using e_commerse.Domain.Abstractions.Domain;
using e_commerse.Domain.ValueObjects.Order;
using e_commerse.Domain.ValueObjects.Payment;
using e_commerse.Domain.ValueObjects.Product;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Events.Payment
{
    public record PaymentRefundedEvent : IDomainEvent
    {
        public DateTime OccurredOn { get; }
        public UserId UserId { get; }
        public OrderId OrderId { get; }
        public PaymentId PaymentId { get; }
        public Money Amount { get; }

        public PaymentRefundedEvent(UserId userId, OrderId orderId,
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
