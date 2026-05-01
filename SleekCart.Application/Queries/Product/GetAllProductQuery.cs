using SleekCart.Application.Abstractions.Queries;
using SleekCart.Application.Common.DTOs;
using SleekCart.Application.DTOs.Product;

namespace SleekCart.Application.Queries.Product;

public sealed record GetAllProductQuery(int PageNumber, int PageSize): IQuery<PagedResult<ProductDto>>;
