using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.OrderStatusHistory
{
    public class EmptyOrderHistoryId: OrderStatusHistoryException
    {
        public EmptyOrderHistoryId()
            : base("Order history id cannot be empty.")
        {
            
        }
    }
}
