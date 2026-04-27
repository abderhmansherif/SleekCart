using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Notification;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface INotificationRepository
    {
        Task<Notification> GetAsync(NotificationId notificationId, CancellationToken ct);
        Task InsertAsync(Notification notification, CancellationToken ct);
        Task UpdateAsync(Notification notification, CancellationToken ct);
        Task DeleteAsync(NotificationId notificationId, CancellationToken ct);
    }
}
