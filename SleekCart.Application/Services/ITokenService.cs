using SleekCart.Domain.Enums.User;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Application.Services;

public interface ITokenService
{
    Task<(Guid JWTId, string Token)> GenerateAccessTokenAsync(UserId UserId, string FullName, string Email, UserRole Role);
    Task<string> GenerateRefreshTokenAsync(UserId UserId, Guid JWTId, bool rememberMe);
}
