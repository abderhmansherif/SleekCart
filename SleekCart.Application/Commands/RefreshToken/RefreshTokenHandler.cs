using e_commerse.Domain.Abstractions.Repositories;
using FluentValidation;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.DTOs;
using SleekCart.Application.Exceptions;
using SleekCart.Application.Services;

namespace SleekCart.Application.Commands.RefreshToken;

public sealed class RefreshTokenHandler : ICommandHandler<RefreshTokenCommand, AuthResponseDto>
{
    private readonly IValidator<RefreshTokenCommand> validator;
    private readonly ITokenService tokenService;
    private readonly IUserRepository userRepository;

    public RefreshTokenHandler(IValidator<RefreshTokenCommand> validator, ITokenService tokenService,
                IUserRepository userRepository)
    {
        this.validator = validator;
        this.tokenService = tokenService;
        this.userRepository = userRepository;
    }
    public async Task<AuthResponseDto> HandleAsync(RefreshTokenCommand command, CancellationToken ct)
    {
        var validationResults = validator.Validate(command);

        if(!validationResults.IsValid)
        {
            throw new ValidationFailedException(validationResults.Errors);
        }
        
        if(! await tokenService.VerifyToken(command.AccessToken, command.RefreshToken))
        {
            throw new InvalidTokensException();
        }
        
        var RefreshToken = await tokenService.GetByTokenAsync(command.RefreshToken);

        var user = await userRepository.GetByIdAsync(RefreshToken.UserId, ct);

        if(user is null)
        {
            throw new NotFoundUserException();
        }

        var (JwtId, Token) = await tokenService.GenerateAccessTokenAsync(user.Id, user.FullName, user.Email, user.Role);

        var newRefreshToken = await tokenService.GenerateRefreshTokenAsync(UserId: user.Id, JWTId: JwtId, ct);

        await tokenService.MarkAsUsed(command.RefreshToken, ct);

        return new AuthResponseDto {AccessToken = Token, RefreshToken = newRefreshToken};
    }
}
