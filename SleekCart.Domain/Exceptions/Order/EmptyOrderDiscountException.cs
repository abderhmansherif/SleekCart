using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Order
{
    public class EmptyOrderDiscountException: OrderException
    {
        public EmptyOrderDiscountException(): base("Order Discount can not be empty.")
        {
            
        }
    }
}
