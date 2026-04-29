using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.User.DeleteAddress;

public sealed record DeleteAddressCommand(Guid UserId, Guid AddressId): ICommand;
