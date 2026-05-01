using SleekCart.Application.DTOs.Category;

namespace SleekCart.Application.DTOs.Product;

public class ProductSummaryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Category { get; set; } 
    public MoneyDto Price { get; set; } = null!;
    public ProductImageDto ProductMainImage { get; set; } = null!;
}
