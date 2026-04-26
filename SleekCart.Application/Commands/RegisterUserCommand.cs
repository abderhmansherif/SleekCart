using SleekCart.Application.Abstractions.Commands;
namespace SleekCart.Application.Commands;

public sealed record RegisterUserCommand(string FullName, string Email, string Password): ICommand;
