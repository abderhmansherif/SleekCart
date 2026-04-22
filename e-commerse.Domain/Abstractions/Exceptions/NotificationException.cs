namespace e_commerse.Domain.Abstractions.Exceptions
{
    public class NotificationException : DomainException
    {
        public NotificationException(string message)
            : base(message)
        {}
    }
}
