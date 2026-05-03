using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Product.UpdateProductDetails;

public sealed record UpdateProductDetailsCommand(
    Guid ProductId,
    string ProductName,
    string ProductDescription,
    decimal Price
    ): ICommand;
