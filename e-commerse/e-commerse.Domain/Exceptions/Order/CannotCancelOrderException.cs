using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Order
{
    public class CannotCancelOrderException: OrderException
    {
        public CannotCancelOrderException(): base("Cannot cancel the order in its current status.")
        {
            
            
        }
    }
}
