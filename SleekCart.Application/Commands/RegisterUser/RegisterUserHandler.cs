using e_commerse.Domain.Abstractions.Factories;
using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;
using SleekCart.Application.RegisterUser;
using SleekCart.Application.Services;
using SleekCart.Domain.Enums.User;

namespace SleekCart.Application.Commands.RegisterUser;

public sealed class RegisterUserHandler : ICommandHandler<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserFactory _userFactory;
    private readonly IIdentityService _identityService;
    public RegisterUserHandler(IUserFactory userFactory, IUserRepository userRepository,
            IIdentityService identityService)
    {
        _userRepository = userRepository;
        _userFactory = userFactory;
        _identityService = identityService;
    }
    public async Task HandleAsync(RegisterUserCommand command, CancellationToken ct)
    {
        var (fullName, email, password) = command;

        var user = await _userRepository.GetAsync(email);

        if(user is not null)
        {
            throw new AlreadyUserRegisteredException(email);
        }

        var uerId = await _identityService.RegisterAsync(email, password, UserRole.Customer);

        var newUser = _userFactory.CreateCustomer(uerId, fullName, email);

        await _userRepository.InsertAsync(newUser);
    }
}
