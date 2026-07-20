using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Notification.MarkAllAsRead;

public record MarkAllAsReadCommand(Guid UserId): ICommand;
