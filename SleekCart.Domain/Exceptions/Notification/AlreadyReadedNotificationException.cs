using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Notification
{
    public class AlreadyReadedNotificationException: NotificationException
    {
        public AlreadyReadedNotificationException()
            : base("Notification is already marked as read.")
        { }
    }
}
