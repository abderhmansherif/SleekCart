using e_commerse.Domain.Exceptions.Payment;

namespace e_commerse.Domain.ValueObjects.Payment
{
    public record PaymentId
    {
        public Guid Value { get; }

        public PaymentId(Guid value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                throw new EmptyPaymentIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(PaymentId paymentId) => paymentId.Value;

        public static implicit operator PaymentId(Guid value) => new PaymentId(value);
    }
}
