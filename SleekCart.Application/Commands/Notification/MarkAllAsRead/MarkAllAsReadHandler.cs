using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Notification.MarkAllAsRead;

public sealed class MarkAllAsReadHandler : ICommandHandler<MarkAllAsReadCommand>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MarkAllAsReadHandler(INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
    {
        this._notificationRepository = notificationRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(MarkAllAsReadCommand command, CancellationToken ct)
    {
        var notifications = await _notificationRepository.GetAllByUserIdAsync(command.UserId, ct);

        foreach (var noti in notifications)
        {
            if(!noti.IsRead)
                noti.MarkAsRead();
        }

        await _unitOfWork.SaveChangesAsync(ct);
    }
}
