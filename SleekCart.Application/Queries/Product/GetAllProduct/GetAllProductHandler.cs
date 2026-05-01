using SleekCart.Application.Common.DTOs;
using SleekCart.Application.DTOs.Product;
using SleekCart.Application.Services;
using SleekCart.Shared.Abstractions.Queries;

namespace SleekCart.Application.Queries.Product.GetAllProduct;

public sealed class GetAllProductHandler : IQueryHandler<GetAllProductQuery, PagedResult<ProductSummaryDto>>
{
    private readonly IProductReadService _productReadService;

    public GetAllProductHandler(IProductReadService productReadService)
    {
        this._productReadService = productReadService;
    }
    public async Task<PagedResult<ProductSummaryDto>> HandleAsync(GetAllProductQuery query, CancellationToken ct)
        
        => await _productReadService.GetAllAsync(query.PageNumber, query.PageSize, ct);
}
