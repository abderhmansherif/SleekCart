using SleekCart.Application.Abstractions.Queries;
using SleekCart.Application.DTOs.Notification;

namespace SleekCart.Application.Queries.Notification.GetMyNotifications;

public sealed record GetMyNotificationsQuery(Guid UserId): IQuery<List<NotificationDto>>;
