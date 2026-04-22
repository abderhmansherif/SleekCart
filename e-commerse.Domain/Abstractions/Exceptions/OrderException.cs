namespace e_commerse.Domain.Abstractions.Exceptions
{
    public abstract class OrderException: DomainException
    {
        public OrderException(string message) : base(message)
        {
            
        }
    }
}
