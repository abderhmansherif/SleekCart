namespace SleekCart.Application.Exceptions;

public class NotificationNotFoundException : ApplicationException
{
    public NotificationNotFoundException(string NotificationId)
        : base($"Notification with id '{NotificationId}' was not found.")
    {}
}