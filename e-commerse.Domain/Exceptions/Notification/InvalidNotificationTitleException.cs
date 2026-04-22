using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Notification
{
    public class InvalidNotificationTitleException: NotificationException
    {
        public InvalidNotificationTitleException(string message): base(message)
        {
        }
    }
}
