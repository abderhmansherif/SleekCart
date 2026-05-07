using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Cart.UpdateItemQuantity;

public sealed record UpdateItemQuantityCommand(Guid CartId, Guid ProductId, int NewQuantity): ICommand;
