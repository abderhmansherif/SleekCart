using e_commerse.Domain.Abstractions.Factories;
using e_commerse.Domain.Entities;
using e_commerse.Domain.ValueObjects.Notification;
using e_commerse.Domain.ValueObjects.User;
using e_commerse.Domain.Enums.Notification;

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
