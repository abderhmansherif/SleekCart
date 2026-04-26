using SleekCart.Application.Abstractions.Commands;
namespace SleekCart.Application.RegisterUser;

public sealed record RegisterUserCommand(string FullName, string Email, string Password): ICommand;
