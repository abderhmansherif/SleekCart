using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Notification;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface INotificationRepository
    {
        Task<Notification> GetAsync(NotificationId notificationId, UserId userId,  CancellationToken ct);
        Task InsertAsync(Notification notification, CancellationToken ct);
        Task UpdateAsync(Notification notification, CancellationToken ct);
        Task DeleteAsync(NotificationId notificationId, CancellationToken ct);
    }
}
