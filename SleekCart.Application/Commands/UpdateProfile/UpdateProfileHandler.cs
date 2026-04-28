using e_commerse.Domain.Abstractions.Repositories;
using FluentValidation;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;

namespace SleekCart.Application.Commands.UpdateProfile;

public sealed class UpdateProfileHandler: ICommandHandler<UpdateProfileCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IValidator<UpdateProfileCommand> _validator;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProfileHandler(IUserRepository userRepository, IValidator<UpdateProfileCommand> validator, 
                IUnitOfWork unitOfWork)
    {
        this._userRepository = userRepository;
        this._validator = validator;
        this._unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(UpdateProfileCommand command, CancellationToken ct)
    {
        var user = await _userRepository.GetByIdAsync(command.UserId, ct);

        if(user is null)
        {
            throw new NotFoundUserException();
        }

        user.UpdateFullName(new Domain.ValueObjects.User.UserFullName(command.NewFullName));

        await _userRepository.UpdateAsync(user, ct);
        await _unitOfWork.SaveChangesAsync();
    }
}
