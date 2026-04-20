using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Cart
{
    public class EmptyCurrencyException : CartException
    {
        public EmptyCurrencyException() : base("Currency cannot be empty.")
        {
        }
    }
}
