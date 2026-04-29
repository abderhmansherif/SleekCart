using e_commerse.Domain.Abstractions.Repositories;
using FluentValidation;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;
using SleekCart.Domain.Entities;

namespace SleekCart.Application.Commands.User.AddAddress;

public sealed class AddAddressHandler : ICommandHandler<AddAddressCommand>
{
    private readonly IUserRepository userRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IValidator<AddAddressCommand> validator;

    public AddAddressHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IValidator<AddAddressCommand> validator)
    {
        this.userRepository = userRepository;
        this.unitOfWork = unitOfWork;
        this.validator = validator;
    }
    public async Task HandleAsync(AddAddressCommand command, CancellationToken ct)
    {
        var result = validator.Validate(command);

        if(!result.IsValid)
        {
            throw new ValidationFailedException(result.Errors);
        }

        var user = await userRepository.GetByIdAsync(command.UserId, ct);

        if(user is null)
        {
            throw new NotFoundUserException();
        }
        
        var newAddress = new Address
        (
            id: Guid.NewGuid(), 
            userId: user.Id, 
            city: command.City, 
            street: command.Street,
            building: command.Building,
            note: command.Note
        );

        user.AddAddress(newAddress);
        await userRepository.UpdateAsync(user, ct);
        await unitOfWork.SaveChangesAsync();
    }
}
