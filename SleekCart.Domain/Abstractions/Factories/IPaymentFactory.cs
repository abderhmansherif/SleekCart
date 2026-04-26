
using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Order;
using SleekCart.Domain.ValueObjects.Payment;
using SleekCart.Domain.ValueObjects.Product;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Factories
{
    public interface IPaymentFactory
    {
        Payment CreateStripePayment(PaymentId id, OrderId orderId, UserId userId,
            Money amount);

        Payment CreatePayPalPayment(PaymentId id, OrderId orderId, UserId userId,
            Money amount);
        
        Payment CreateCashPayment(PaymentId id, OrderId orderId, UserId userId,
            Money amount);
    }
}
