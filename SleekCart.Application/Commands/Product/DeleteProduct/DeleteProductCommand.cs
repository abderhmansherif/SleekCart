
using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Product.DeleteProduct;

public sealed record DeleteProductCommand(Guid ProductId): ICommand;
