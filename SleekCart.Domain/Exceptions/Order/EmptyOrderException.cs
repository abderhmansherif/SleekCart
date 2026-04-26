using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Order
{
    public class EmptyOrderException: OrderException
    {
        public EmptyOrderException(): base("The order cannot be empty, please add items before proceeding.")
        {
            
        }
    }
}
