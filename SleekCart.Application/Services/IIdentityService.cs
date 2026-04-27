using SleekCart.Domain.Enums.User;

namespace SleekCart.Application.Services;

public interface IIdentityService
{
    Task<Guid> RegisterAsync(string Email, string Password, UserRole role);
    Task<bool> CheckPasswordAsync(string email, string password);
}