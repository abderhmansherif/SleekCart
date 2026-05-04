using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Product.SetProductImageMain;

public sealed record SetProductImageMainCommand(Guid ProductId, Guid ImageId) : ICommand;
