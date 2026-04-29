

using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Authentication.RefreshToken;

public sealed record RefreshTokenCommand(string AccessToken, string RefreshToken): ICommand;
