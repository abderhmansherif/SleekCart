namespace e_commerse.Domain.Abstractions.Exceptions
{
    public abstract class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}
