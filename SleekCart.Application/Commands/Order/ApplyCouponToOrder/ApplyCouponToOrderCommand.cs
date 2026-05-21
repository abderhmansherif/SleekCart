using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Order.ApplyCouponToOrder;

public sealed record ApplyCouponToOrderCommand(Guid OrderId, string CouponCode): ICommand;
