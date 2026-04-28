using SleekCart.Application.DTOs;
using SleekCart.Domain.Entities;

namespace SleekCart.Application.Mappers;
public static class UserProfileMapper
{
    public static ProfileDto ToProfile(this User user, List<Order>? orders)
        => new ProfileDto
        {
            UserId = user.Id.Value,
            FullName = user.FullName.Value,
            Email = user.Email.Value,
            JoinedAt = user.JoinedAt,
            Orders = orders?.Select(x => new OrderDto
            {
                OrderId = x.Id.Value,
                Status = x.Status.ToString(),
                TotalPrices = x.Total.Amount.ToString(),
                CreatedAt = x.CreatedAt

            }).ToList(),
        };
}
