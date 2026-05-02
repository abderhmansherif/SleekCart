namespace SleekCart.Application.DTOs.Product;

public class ImageDto
{
    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public Stream Stream { get; set; } = null!;
}
