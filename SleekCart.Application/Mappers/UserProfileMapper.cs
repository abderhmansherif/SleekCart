using SleekCart.Application.Order.DTOs;
using SleekCart.Application.User.DTOs;
namespace SleekCart.Application.Mappers;
public static class UserProfileMapper
{
    public static ProfileDto ToProfile(this SleekCart.Domain.Entities.User user, List<OrderDto>? orders)
        => new ProfileDto
        {
            UserId = user.Id.Value,
            FullName = user.FullName.Value,
            Email = user.Email.Value,
            JoinedAt = user.JoinedAt,
            Orders = orders,
        };
}
