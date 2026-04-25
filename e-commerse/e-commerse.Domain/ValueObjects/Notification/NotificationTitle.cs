using e_commerse.Domain.Exceptions.Notification;

namespace e_commerse.Domain.ValueObjects.Notification
{
    public record NotificationTitle
    {
        public string Value { get;}
        internal NotificationTitle(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyNotificationTitleException();
            }

            if (value.Length > 100)
            {
                throw new InvalidNotificationTitleException("Notification title cannot exceed 100 characters.");
            }

            this.Value = value;
        }

        public static implicit operator string(NotificationTitle title) => title.Value;
        public static implicit operator NotificationTitle(string title) => new NotificationTitle(title);
    }
}
