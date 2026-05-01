using SleekCart.Application.Abstractions.Queries;
using SleekCart.Application.Common.DTOs;
using SleekCart.Application.User.DTOs;

namespace SleekCart.Application.Queries.User.GetAllUsers;

public sealed record GetAllUsersQuery(int PageNumber, int PageSize): IQuery<PagedResult<UserDto>>;
