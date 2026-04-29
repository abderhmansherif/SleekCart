using SleekCart.Application.DTOs;
using SleekCart.Domain.Entities;

namespace SleekCart.Application.Mappers;

public static class UserMapper
{
    public static UserDto ToDTO(this User user)
        => new UserDto
        {
            UserId = user.Id.Value,
            FullName = user.FullName.Value,
            Email = user.Email.Value,
            Role = user.Role.ToString()  
        };
}
