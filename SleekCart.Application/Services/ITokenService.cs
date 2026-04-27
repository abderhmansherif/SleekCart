using SleekCart.Domain.Enums.User;

namespace SleekCart.Application.Services;

public interface ITokenService
{
    Task<string> GenerateTokenAsync(string fullName, string email, UserRole role);
}
