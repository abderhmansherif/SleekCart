using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.LoginUser;

public sealed class LoginUserHandler : ICommandHandler<LoginUserCommand>
{
    private readonly IUserRepository _repository;
    public LoginUserHandler(IUserRepository repository)
        => _repository = repository;

    public async Task HandleAsync(LoginUserCommand command, CancellationToken ct)
    {
        var (email, password) = command;

        var user = await _repository.GetAsync(email, ct);

        if(user is null)
        {
            
        }
    }
}
