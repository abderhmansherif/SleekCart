using e_commerse.Domain.Abstractions.Factories;
using SleekCart.Domain.Entities;
using SleekCart.Domain.Enums.Payment;
using SleekCart.Domain.ValueObjects.Order;
using SleekCart.Domain.ValueObjects.Payment;
using SleekCart.Domain.ValueObjects.Product;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Factories
{
    public class PaymentFactory: IPaymentFactory
    {
        public Payment CreateCashPayment(PaymentId id, OrderId orderId, UserId userId, Money amount)
            => new Payment(id, orderId, userId, amount, PaymentProvider.Cash);

        public Payment CreatePayPalPayment(PaymentId id, OrderId orderId, UserId userId, Money amount)
            => new Payment(id, orderId, userId, amount, PaymentProvider.PayPal);

        public Payment CreateStripePayment(PaymentId id, OrderId orderId, UserId userId, Money amount)
            => new Payment(id ,orderId, userId, amount, PaymentProvider.Stripe);
    }
}
