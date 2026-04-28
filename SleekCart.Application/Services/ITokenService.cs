using SleekCart.Domain.Entities;
using SleekCart.Domain.Enums.User;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Application.Services;

public interface ITokenService
{
    Task<(Guid JWTId, string Token)> GenerateAccessTokenAsync(UserId UserId, string FullName, string Email, UserRole Role);
    Task<string> GenerateRefreshTokenAsync(UserId UserId, Guid JWTId, CancellationToken ct, bool rememberMe = false);
    Task<bool> VerifyToken(string AccessToken, string RefreshToken);
    Task MarkAsUsed(string RefreshToken, CancellationToken ct);
    Task<RefreshToken> GetByTokenAsync(string RefreshToken);
}
