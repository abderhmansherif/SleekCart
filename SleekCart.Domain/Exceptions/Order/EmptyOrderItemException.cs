using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Order
{
    public class EmptyOrderItemException: OrderException
    {
        public EmptyOrderItemException(): base("Order product can not be empty.")
        {
            
        }
    }
}
