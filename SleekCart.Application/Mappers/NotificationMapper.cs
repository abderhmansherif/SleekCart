using SleekCart.Application.DTOs.Notification;
using SleekCart.Domain.Entities;

namespace SleekCart.Application.Mappers;

public static class NotificationMapper
{
    public static NotificationDto ToDto(this Notification notification)
        => new NotificationDto
        {
            NotificationId = notification.Id.Value,
            Type = notification.Type.ToString(),
            Title = notification.Title.Value,
            Message = notification.Message.Value,
            IsRead = notification.IsRead,
            CreatedAt = notification.CreatedAt
        };
}
