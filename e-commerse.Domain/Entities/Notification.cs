using e_commerse.Domain.Enums.Notification;
using e_commerse.Domain.Exceptions.Notification;
using e_commerse.Domain.ValueObjects.Notification;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Entities
{
    internal class Notification
    {
        public NotificationId Id { get; private set; }
        public UserId UserId { get; private set; }
        public NotificationType Type { get; private set; }
        public NotificationTitle Title { get; private set; }
        public NotificationMessage Message { get; private set; }
        public bool IsRead { get; private set; } 
        public DateTime CreatedAt { get; private set; } 

        internal Notification(NotificationId id, UserId userId, 
            NotificationType type, NotificationTitle title, NotificationMessage message)
        {
            this.Id = id;
            this.UserId = userId;
            this.Type = type;
            this.Title = title;
            this.Message = message;
            this.IsRead = false;
            this.CreatedAt = DateTime.UtcNow;
        }

        public void MarkAsRead()
        {
            if(IsRead)
            {
                throw new AlreadyReadedNotificationException();
            }
                
            IsRead = true;
        }
    }
}
