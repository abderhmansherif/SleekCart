using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Notification.MarkAsRead;

public record MarkAsReadCommand(Guid NotificationId, Guid UserId): ICommand;
