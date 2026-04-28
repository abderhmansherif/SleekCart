using e_commerse.Domain.Abstractions.Repositories;
using FluentValidation;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.DTOs;
using SleekCart.Application.Exceptions;
using SleekCart.Application.Services;

namespace SleekCart.Application.Commands.LoginUser;

public sealed class LoginUserHandler : ICommandHandler<LoginUserCommand, AuthResponseDto>
{
    private readonly IUserRepository _repository;
    private readonly IValidator<LoginUserCommand> _validator;
    private readonly IIdentityService _identityService;
    private readonly ITokenService _tokenService;
    public LoginUserHandler(IUserRepository repository, ITokenService tokenService,
            IIdentityService identityService, IValidator<LoginUserCommand> validator)
    {
        _repository = repository;
        _validator = validator;
        _tokenService = tokenService;
        _identityService = identityService;
    }
    public async Task<AuthResponseDto> HandleAsync(LoginUserCommand command, CancellationToken ct)
    {
        var validationResults = _validator.Validate(command);

        if(!validationResults.IsValid)
        {
            throw new ValidationFailedException(validationResults.Errors);
        }
        
        var (email, password, rememberMe) = command;

        var user = await _repository.GetAsync(email, ct);

        if(user is null)
        {
            throw new NotFoundUserException();
        }

        if(! await _identityService.CheckPasswordAsync(email, password))
        {
            throw new InvalidCredentialsException();
        }

        var (JwtId, Token) = await _tokenService.GenerateAccessTokenAsync(user.Id, user.FullName, user.Email, user.Role);

        var RefreshTokenDuration = rememberMe? TimeSpan.FromDays(30) : TimeSpan.FromDays(7);

        var RefreshToken = await _tokenService.GenerateRefreshTokenAsync(user.Id, JwtId, RefreshTokenDuration);

        return new AuthResponseDto{AccessToken = Token, RefreshToken = RefreshToken};
    }
}
