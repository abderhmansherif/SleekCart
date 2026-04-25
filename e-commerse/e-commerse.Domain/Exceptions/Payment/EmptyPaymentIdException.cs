using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Payment
{
    public class EmptyPaymentIdException : PaymentException
    {
        public EmptyPaymentIdException()
            : base("Payment ID cannot be empty.")
        {
        }
    }
}
