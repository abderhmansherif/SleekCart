using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;

namespace SleekCart.Application.Commands.Notification.MarkAsRead;

public sealed class MarkAsReadHandler : ICommandHandler<MarkAsReadCommand>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MarkAsReadHandler(INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
    {
        this._notificationRepository = notificationRepository;
        this._unitOfWork = unitOfWork;
    }
    public async Task HandleAsync(MarkAsReadCommand command, CancellationToken ct)
    {
        var noti = await _notificationRepository.GetAsync(command.NotificationId, command.UserId, ct);

        if(noti is null)
            throw new NotificationNotFoundException(command.NotificationId.ToString());

        if(!noti.IsRead)
            noti.MarkAsRead();

        await _unitOfWork.SaveChangesAsync(ct);
    }
}