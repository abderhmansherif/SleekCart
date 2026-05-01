using SleekCart.Application.User.DTOs;

namespace SleekCart.Application.Mappers;

public static class UserMapper
{
    public static UserDto ToDTO(this SleekCart.Domain.Entities.User user)
        => new UserDto
        {
            UserId = user.Id.Value,
            FullName = user.FullName.Value,
            Email = user.Email.Value,
            Role = user.Role.ToString()  
        };
}
