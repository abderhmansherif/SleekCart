using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.DTOs.Product;

namespace SleekCart.Application.Commands.Cart.AddItemToCart;

public sealed record AddItemToCartCommand(Guid ProductId, Guid CartId ,int Quantity, MoneyDto money) :ICommand;
