using SleekCart.Application.DTOs.Category;

namespace SleekCart.Application.DTOs.Product;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public MoneyDto Price { get; set; } = null!;
    public int StockAmount { get; set; }
    public CategoryDto? Category { get; set; }
    public List<ProductImageDto> Images { get; set; } = new();
}
