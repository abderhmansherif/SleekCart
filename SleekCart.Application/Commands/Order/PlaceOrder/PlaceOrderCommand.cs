using SleekCart.Application.Abstractions.Commands;
using SleekCart.Domain.ValueObjects.Cart;
using SleekCart.Domain.ValueObjects.Order;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Application.Commands.Order.PlaceOrder;

public sealed record PlaceOrderCommand(CartId CartId, UserId UserId, ShippingAddress ShippingAddress): ICommand;
