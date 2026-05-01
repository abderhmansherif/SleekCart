using SleekCart.Application.Common.DTOs;
using SleekCart.Application.Services;
using SleekCart.Application.User.DTOs;
using SleekCart.Shared.Abstractions.Queries;

namespace SleekCart.Application.Queries.User.GetAllUsers;

public class GetAllUsersHandler: IQueryHandler<GetAllUsersQuery, PagedResult<UserDto>>
{
    private readonly IUserReadService readService;

    public GetAllUsersHandler(IUserReadService readService)
    {
        this.readService = readService;
    }

    public async Task<PagedResult<UserDto>> HandleAsync(GetAllUsersQuery query, CancellationToken ct)
    
        => await readService.GetAllAsync(query.PageNumber, query.PageSize, ct);
}
