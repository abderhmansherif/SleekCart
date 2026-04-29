using SleekCart.Application.Abstractions.Commands;
namespace SleekCart.ApplicationCommands.Authentication.RegisterUser;

public sealed record RegisterUserCommand(string FullName, string Email, string Password): ICommand;
