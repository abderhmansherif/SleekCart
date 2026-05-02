
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.DTOs.Product;
using SleekCart.Domain.ValueObjects.Product;

namespace SleekCart.Application.Commands.Product.CreateProduct;

public sealed record CreateProductCommand :ICommand
{
    public string ProductName { get; } = string.Empty;
    public string ProductDescription { get; } = string.Empty;
    public Money Price { get; } = null!;
    public int StockQuantity { get; } 
    public List<ImageDto> Images { get; } = null!;
    public Guid? CategoryId { get; }
}
