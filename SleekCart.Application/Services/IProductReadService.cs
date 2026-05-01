using SleekCart.Application.Common.DTOs;
using SleekCart.Application.DTOs.Product;

namespace SleekCart.Application.Services;

public interface IProductReadService
{
    Task<PagedResult<ProductSummaryDto>> GetAllAsync(int PageNumber, int PageSize, CancellationToken ct);
}
