using e_commerse.Domain.Abstractions.Factories;
using e_commerse.Domain.Entities;
using e_commerse.Domain.Enums.Payment;
using e_commerse.Domain.ValueObjects.Order;
using e_commerse.Domain.ValueObjects.Payment;
using e_commerse.Domain.ValueObjects.Product;
using e_commerse.Domain.ValueObjects.User;

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
