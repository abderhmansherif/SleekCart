using SleekCart.Application.Services;
using SleekCart.Domain.Events.User;
using SleekCart.Shared.Abstractions.Events;

namespace SleekCart.Application.Events;

public sealed class UserRegisteredEventHandler : IEventHandler<UserRegisteredEvent>
{
    private readonly IEmailService _emailService;

    public UserRegisteredEventHandler(IEmailService emailService)
    {
        this._emailService = emailService;
    }

    public async Task HandleAsync(UserRegisteredEvent @event, CancellationToken ct)
    {
        await _emailService.SendWelcomeEmailAsync(
            userFullName: @event.FullName,
            email: @event.Email,
            ct: ct
        );
    }
}