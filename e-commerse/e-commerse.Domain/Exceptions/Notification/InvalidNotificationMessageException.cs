using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Notification
{
    public class InvalidNotificationMessageException: NotificationException
    {
        public InvalidNotificationMessageException(string message): base(message)
        {
        }
    }
}
