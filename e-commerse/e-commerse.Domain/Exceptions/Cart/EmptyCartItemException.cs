using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Cart
{
    public class EmptyCartItemException: CartException
    {
        public EmptyCartItemException(): base("Cart item cannot be empty.")
        {
            
        }
    }
}
