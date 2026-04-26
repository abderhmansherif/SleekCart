
using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Notification;
using SleekCart.Domain.ValueObjects.User;

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
