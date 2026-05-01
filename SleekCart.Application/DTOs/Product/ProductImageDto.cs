namespace SleekCart.Application.DTOs.Product;

public class ProductImageDto
{
    public Guid Id { get; set; }
    public string FilePath { get; set; } = string.Empty;
    public bool IsMain { get; set; }
}
