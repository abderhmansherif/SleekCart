using e_commerse.Domain.Abstractions.Repositories;
using FluentValidation;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;

namespace SleekCart.Application.Commands.User.DeleteAddress;

public sealed class DeleteAddressHandler: ICommandHandler<DeleteAddressCommand>
{
    private readonly IUserRepository userRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IValidator<DeleteAddressCommand> validator;

    public DeleteAddressHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, 
                                IValidator<DeleteAddressCommand> validator)
    {
        this.userRepository = userRepository;
        this.unitOfWork = unitOfWork;
        this.validator = validator;
    }

    public async Task HandleAsync(DeleteAddressCommand command, CancellationToken ct)
    {
        var result = validator.Validate(command);

        if(!result.IsValid)
        {
            throw new ValidationFailedException(result.Errors);    
        }

        var (userId, addressId) = command;

        var user = await userRepository.GetByIdAsync(userId, ct);

        if(user is null)
        {
            throw new NotFoundUserException();
        }

        user.RemoveAddress(new Domain.ValueObjects.Address.AddressId(addressId));

        await userRepository.UpdateAsync(user, ct);
        await unitOfWork.SaveChangesAsync();
    }
}
