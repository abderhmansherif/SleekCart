using e_commerse.Domain.Exceptions.Notification;

namespace SleekCart.Domain.ValueObjects.Notification
{
    public record NotificationId
    {
        public Guid Value { get;}
        public NotificationId(Guid value)
        {
            if(value == Guid.Empty)
                throw new EmptyNotificationIdException();

            Value = value;
        }
        public static implicit operator Guid(NotificationId notificationId) => notificationId.Value;

        public static implicit operator NotificationId(Guid value) => new(value);
    }
}