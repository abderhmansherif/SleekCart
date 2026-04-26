using e_commerse.Domain.Exceptions.Notification;

namespace SleekCart.Domain.ValueObjects.Notification
{
    public record NotificationMessage
    {
        public string Value { get; }
        internal NotificationMessage(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyNotificationMessageException();
            }

            if (value.Length > 700)
            {
                throw new InvalidNotificationMessageException("Notification message cannot exceed 700 characters.");
            }

            this.Value = value;
        }

        public static implicit operator string(NotificationMessage message) => message.Value;
        public static implicit operator NotificationMessage(string message) => new NotificationMessage(message);
    }
}