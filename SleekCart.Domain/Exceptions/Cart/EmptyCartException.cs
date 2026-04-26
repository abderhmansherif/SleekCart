using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Cart
{
    public class EmptyCartException: CartException
    {
        public EmptyCartException(): base("Cart is empty.")
        {
            
        }
    }
}
