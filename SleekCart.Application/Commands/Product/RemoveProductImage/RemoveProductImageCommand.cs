using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Product.RemoveProductImage;

public sealed record RemoveProductImageCommand(Guid ProductId, Guid ImageId) :ICommand;
