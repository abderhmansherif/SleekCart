using SleekCart.Application.Common.DTOs;
using SleekCart.Application.DTOs.Product;
using SleekCart.Domain.ValueObjects.Category;

namespace SleekCart.Application.Services;

public interface IProductReadService
{
    Task<PagedResult<ProductSummaryDto>> GetAllAsync(int PageNumber, int PageSize, CancellationToken ct);
    Task<PagedResult<ProductSummaryDto>> GetByCategoryIdAsync(CategoryId categoryId, int PageNumber, int PageSize, CancellationToken ct);
}
