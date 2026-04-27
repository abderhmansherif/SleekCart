using e_commerse.Domain.Abstractions.Factories;
using e_commerse.Domain.Abstractions.Repositories;
using FluentValidation;
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
    private readonly IValidator<RegisterUserCommand> _validator;
    public RegisterUserHandler(IUserFactory userFactory, IUserRepository userRepository,
            IIdentityService identityService, IValidator<RegisterUserCommand> validator)
    {
        _userRepository = userRepository;
        _userFactory = userFactory;
        _identityService = identityService;
        _validator = validator;
    }
    public async Task HandleAsync(RegisterUserCommand command, CancellationToken ct)
    {
        var result = _validator.Validate(command);

        if(!result.IsValid)
        {
            throw new ValidationFailedException(result.Errors);
        }

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
