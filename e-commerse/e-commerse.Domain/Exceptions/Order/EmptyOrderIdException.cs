using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Order
{
    public class EmptyOrderIdException: OrderException
    {
        public EmptyOrderIdException(): base("Order Id can not be empty.")
        {
            
        }
    }
}
