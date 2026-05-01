namespace SleekCart.Application.DTOs.Product;

public class ProductDetailsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Descreption { get; set; } = string.Empty;
    public string? Category { get; set; } 
    public int StockQuantity { get; set; }
    public MoneyDto Price { get; set; } = null!;
    public List<ProductImageDto> Images { get; set; } = new();
}
