namespace e_commerse.Domain.Abstractions.Exceptions
{
    public abstract class OrderStatusHistoryException: DomainException
    {
        public OrderStatusHistoryException(string msg): base(msg)
        {
            
        }
    }
}
