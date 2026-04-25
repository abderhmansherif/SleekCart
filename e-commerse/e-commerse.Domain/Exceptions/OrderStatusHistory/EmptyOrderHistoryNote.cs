using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.OrderStatusHistory
{
    public class EmptyOrderHistoryNote : OrderStatusHistoryException
    {
        public EmptyOrderHistoryNote(): base("Order history note cannot be empty.")
        {
            
        }
    }
}
