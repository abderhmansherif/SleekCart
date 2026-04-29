using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.User.DeleteUser;

public sealed record DeleteUserCommand(Guid UserId) :ICommand;
