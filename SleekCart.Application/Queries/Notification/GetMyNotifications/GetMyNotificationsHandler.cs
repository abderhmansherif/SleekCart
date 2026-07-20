using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.DTOs.Notification;
using SleekCart.Application.Mappers;
using SleekCart.Shared.Abstractions.Queries;

namespace SleekCart.Application.Queries.Notification.GetMyNotifications;

public sealed class GetMyNotificationsHandler : IQueryHandler<GetMyNotificationsQuery, List<NotificationDto>>
{
    private readonly INotificationRepository _notificationRepository;

    public GetMyNotificationsHandler(INotificationRepository notificationRepository)
    {
        this._notificationRepository = notificationRepository;
    }

    public async Task<List<NotificationDto>> HandleAsync(GetMyNotificationsQuery query, CancellationToken ct)
    {
        var notifications = await _notificationRepository.GetAllByUserIdAsync(query.UserId, ct);

        return notifications.Select(n => n.ToDto()).ToList();
    }
}
