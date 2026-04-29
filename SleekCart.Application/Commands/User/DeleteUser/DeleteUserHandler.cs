using e_commerse.Domain.Abstractions.Repositories;
using FluentValidation;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;

namespace SleekCart.Application.Commands.User.DeleteUser;

public sealed class DeleteUserHandler: ICommandHandler<DeleteUserCommand>
{
    private readonly IUserRepository userRepository;
    private readonly IValidator<DeleteUserCommand> validator;
    private readonly IUnitOfWork unitOfWork;

    public DeleteUserHandler(IUserRepository userRepository, IValidator<DeleteUserCommand> validator,
                            IUnitOfWork unitOfWork)
    {
        this.userRepository = userRepository;
        this.validator = validator;
        this.unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(DeleteUserCommand command, CancellationToken ct)
    {
        var result = validator.Validate(command);

        if(!result.IsValid)
        {
            throw new ValidationFailedException(result.Errors);
        }

        var user = await userRepository.GetByIdAsync(userId: command.UserId, ct);

        if(user is null)
        {
            throw new NotFoundUserException();
        }

        user.MarkAsDeleted();

        await userRepository.UpdateAsync(user, ct);
        await unitOfWork.SaveChangesAsync();
    }
}
