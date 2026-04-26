using e_commerse.Domain.Entities;
using e_commerse.Domain.ValueObjects.Notification;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Factories
{
    internal interface INotificationFactory
    {
        Notification CreateOrderNotification(NotificationId id, UserId userId,
            NotificationTitle title, NotificationMessage message);
        Notification CreatePaymentNotification(NotificationId id, UserId userId,
            NotificationTitle title, NotificationMessage message);
        Notification CreateSystemNotification(NotificationId id, UserId userId,
            NotificationTitle title, NotificationMessage message);

    }
}
