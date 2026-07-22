using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Application.Services;

public interface IEmailService
{
    Task SendWelcomeEmailAsync(UserFullName userFullName, Email email, CancellationToken ct);
}
