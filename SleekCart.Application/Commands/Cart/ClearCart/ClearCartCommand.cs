using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Cart.ClearCart;

public sealed record ClearCartCommand(Guid CartId) : ICommand;
