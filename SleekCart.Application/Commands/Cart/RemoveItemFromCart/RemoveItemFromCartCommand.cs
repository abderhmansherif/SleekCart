using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Cart.RemoveItemFromCart;

public sealed record RemoveItemFromCartCommand(Guid CartId, Guid ProductId): ICommand;
