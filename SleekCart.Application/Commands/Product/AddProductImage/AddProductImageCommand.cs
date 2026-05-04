using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.DTOs.Product;

namespace SleekCart.Application.Commands.Product.AddProductImage;

public sealed record AddProductImageCommand(Guid ProductId, ImageDto Image) :ICommand;
