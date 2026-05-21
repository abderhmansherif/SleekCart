using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Order.CancelOrder;

public sealed record CancelOrderCommand(Guid OrderId): ICommand;
