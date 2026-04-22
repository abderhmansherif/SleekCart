using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Notification
{
    public class EmptyNotificationMessageException: NotificationException
    {
        public EmptyNotificationMessageException(): base("Notification message cannot be empty.")
        {
            
        }
    }
}
