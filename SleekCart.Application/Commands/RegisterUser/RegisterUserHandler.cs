using e_commerse.Domain.Abstractions.Factories;
using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.RegisterUser;


namespace SleekCart.Application.Commands.RegisterUser;

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
