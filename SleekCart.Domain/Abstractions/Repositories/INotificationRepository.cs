using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Notification;

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
