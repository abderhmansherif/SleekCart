using SleekCart.Application.Abstractions.Commands;
namespace SleekCart.Application.Commands.LoginUser;

public sealed record LoginUserCommand(string Email, string Password): ICommand;
