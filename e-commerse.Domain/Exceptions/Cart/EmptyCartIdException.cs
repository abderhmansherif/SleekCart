using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Cart
{
    public class EmptyCartIdException : CartException
    {
        public EmptyCartIdException() : base("Cart Id cannot be empty.")
        {
        }
    }
}
