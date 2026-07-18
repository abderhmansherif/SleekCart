using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Payment.PayForOrder;

public record PayForOrderCommand(Guid OrderId, Guid UserId, string PaymentProvider): ICommand;
