using e_commerse.Domain.Enums.Payment;
using e_commerse.Domain.ValueObjects.Order;
using e_commerse.Domain.ValueObjects.Payment;
using e_commerse.Domain.ValueObjects.Product;

namespace e_commerse.Domain.Entities
{
    public class Payment
    {
        public PaymentId Id { get; private set; }
        public OrderId OrderId { get; private set; }
        public Money Amount { get; private set; }
        public PaymentStatus Status { get; private set; }
        public PaymentProvider Provider { get; private set; }
        public DateTime CreatedAt { get; private set; }

        internal Payment(PaymentId id, OrderId orderId, Money amount, PaymentProvider provider)
        {
            Id = id;
            OrderId = orderId;
            Amount = amount;
            Status = PaymentStatus.Pending;
            Provider = provider;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
