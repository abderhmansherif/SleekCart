using e_commerse.Domain.Abstractions.Factories;
using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;


namespace SleekCart.Application.Commands.Handlers;

public sealed class RegisterUserHandler : ICommandHandler<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserFactory _userFactory;
    public RegisterUserHandler(IUserFactory userFactory, IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _userFactory = userFactory;
    }
    public async Task HandleAsync(RegisterUserCommand command, CancellationToken ct)
    {
        
    }
}
