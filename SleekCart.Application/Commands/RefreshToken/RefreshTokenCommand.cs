

using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.RefreshToken;

public sealed record RefreshTokenCommand(string AccessToken, string RefreshToken): ICommand;
