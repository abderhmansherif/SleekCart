using e_commerse.Domain.Abstractions.Factories;
using SleekCart.Domain.Entities;
using SleekCart.Domain.Enums.Notification;
using SleekCart.Domain.ValueObjects.Notification;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Factories
{
    public class NotificationFactory : INotificationFactory
    {
        public Notification CreateOrderNotification(NotificationId id, UserId userId, NotificationTitle title, NotificationMessage message)
            => new Notification(id, userId, NotificationType.Order, title, message);

        public Notification CreatePaymentNotification(NotificationId id, UserId userId, NotificationTitle title, NotificationMessage message)
            => new Notification(id, userId, NotificationType.Payment, title, message);

        public Notification CreateSystemNotification(NotificationId id, UserId userId, NotificationTitle title, NotificationMessage message)
            => new Notification(id, userId, NotificationType.System, title, message);
    }
}
