using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Notification
{
    public class EmptyNotificationTitleException: NotificationException
    {
        public EmptyNotificationTitleException(): base("Notification title cannot be empty.")
        {
            
        }
    }
}
