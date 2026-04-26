using SleekCart.Domain.Abstractions.Domain;
using SleekCart.Domain.Enums.Payment;
using SleekCart.Domain.Events.Payment;
using SleekCart.Domain.ValueObjects.Order;
using SleekCart.Domain.ValueObjects.Payment;
using SleekCart.Domain.ValueObjects.Product;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Domain.Entities
{
    public class Payment : AggregateRoot
    {
        public PaymentId Id { get; private set; }
        public OrderId OrderId { get; private set; }
        public UserId UserId { get; private set; }
        public Money Amount { get; private set; }
        public PaymentStatus Status { get; private set; }
        public PaymentProvider Provider { get; private set; }
        public DateTime CreatedAt { get; private set; }

        internal Payment(PaymentId id, OrderId orderId, UserId userId,
            Money amount, PaymentProvider provider)
        {
            Id = id;
            OrderId = orderId;
            Amount = amount;
            UserId = userId;
            Status = PaymentStatus.Pending;
            Provider = provider;
            CreatedAt = DateTime.UtcNow;
        }

        public void MarkAsCompleted()
        {
            Status = PaymentStatus.Succeeded;

            // Raise domain event
            RaiseDomainEvent(new PaymentSucceededEvent(this.UserId, this.OrderId, this.Id, this.Amount));
        }

        public void MarkAsFailed()
        {
            Status = PaymentStatus.Failed;

            // Raise domain event
            RaiseDomainEvent(new PaymentFailedEvent(this.UserId, this.OrderId, this.Id, this.Amount));
        }

        public void MarkAsRefunded()
        {
            Status = PaymentStatus.Refunded;

            // Raise domain event
            RaiseDomainEvent(new PaymentRefundedEvent(this.UserId, this.OrderId, this.Id, this.Amount));
        }
    }
}
