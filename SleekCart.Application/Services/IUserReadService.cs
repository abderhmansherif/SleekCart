using SleekCart.Application.DTOs;

namespace SleekCart.Application.Services;

public interface IUserReadService
{
    Task<PagedResult<UserDto>> GetAllAsync(int PageNumber, int PageSize, CancellationToken ct);
}
