using e_commerse.Domain.Entities;
using e_commerse.Domain.ValueObjects.Notification;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface INotificationRepository
    {
        Task<Notification> GetAsync(NotificationId notificationId);
        Task InsertAsync(Notification notification);
        Task UpdateAsync(Notification notification);
        Task DeleteAsync(NotificationId notificationId);
    }
}
