using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Cart
{
    public class CurrencyMismatchException : CartException
    {
        public CurrencyMismatchException() : base("Currency mismatch between cart items.")
        {

        }
    }
}
