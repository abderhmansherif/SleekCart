using SleekCart.Application.Order.DTOs;

namespace SleekCart.Application.User.DTOs;

public class ProfileDto
{
    public Guid UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime JoinedAt { get; set; }

    public List<OrderDto>? Orders {get; set;} 
}
