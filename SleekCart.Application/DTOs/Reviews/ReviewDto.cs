namespace SleekCart.Application.DTOs.Reviews;

public class ReviewDto
{
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public decimal Rating { get; set; }
    public string Comment { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}