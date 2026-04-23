using e_commerse.Domain.Entities;
using e_commerse.Domain.Enums.Payment;
using e_commerse.Domain.ValueObjects.Order;
using e_commerse.Domain.ValueObjects.Payment;
using e_commerse.Domain.ValueObjects.Product;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Factories
{
    public interface IPaymentFactory
    {
        Payment Create(PaymentId id, OrderId orderId, UserId userId,
            Money amount, PaymentProvider provider);
    }
}
