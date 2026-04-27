using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.LoginUser;

public sealed class LoginUserHandler : ICommandHandler<LoginUserCommand>
{
    public Task HandleAsync(LoginUserCommand command, CancellationToken ct)
    {
        
    }
}
