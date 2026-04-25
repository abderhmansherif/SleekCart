namespace e_commerse.Domain.Abstractions.Exceptions
{
    public abstract class ReviewException: DomainException
    {
        public ReviewException(string message) : base(message)
        {   
        }
    }
}
