using SleekCart.Application.Abstractions.Queries;
using SleekCart.Application.Common.DTOs;
using SleekCart.Application.DTOs.Product;

namespace SleekCart.Application.Queries.Product.GetProductsByCategory;

public sealed record GetProductsByCategoryQuery(Guid CategoryId, int PageNumber, int PageSize)
                : IQuery<PagedResult<ProductSummaryDto>>;
