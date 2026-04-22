namespace e_commerse.Domain.Abstractions.Exceptions
{
    public abstract class UserException : DomainException
    {
        public UserException(string message) : base(message)
        {
        }
    }
}
