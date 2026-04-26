using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Notification
{
    public class EmptyNotificationIdException: NotificationException
    {
        public EmptyNotificationIdException(): base("NotificationId cannot be empty.")
        {
            
        }
    }
}
