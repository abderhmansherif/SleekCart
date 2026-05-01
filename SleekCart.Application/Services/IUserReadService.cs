using SleekCart.Application.Common.DTOs;
using SleekCart.Application.DTOs;
using SleekCart.Application.User.DTOs;

namespace SleekCart.Application.Services;

public interface IUserReadService
{
    Task<PagedResult<UserDto>> GetAllAsync(int PageNumber, int PageSize, CancellationToken ct);
}
