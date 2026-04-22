namespace e_commerse.Domain.Abstractions.Exceptions
{
    public class UserException : DomainException
    {
        public UserException(string message) : base(message)
        {
        }
    }
}
