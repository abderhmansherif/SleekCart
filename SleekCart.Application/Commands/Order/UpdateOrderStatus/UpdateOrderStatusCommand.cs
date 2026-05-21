using SleekCart.Application.Abstractions.Commands;
using SleekCart.Domain.Enums.Order;

namespace SleekCart.Application.Commands.Order.UpdateOrderStatus;

public sealed record UpdateOrderStatusCommand(Guid OrderId, string NewStatus):ICommand;
