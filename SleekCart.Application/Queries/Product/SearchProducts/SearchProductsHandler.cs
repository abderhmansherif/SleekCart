using SleekCart.Application.Common.DTOs;
using SleekCart.Application.DTOs.Product;
using SleekCart.Application.Services;
using SleekCart.Shared.Abstractions.Queries;

namespace SleekCart.Application.Queries.Product.SearchProducts;

public sealed class SearchProductsHandler: IQueryHandler<SearchProductsQuery, PagedResult<ProductSummaryDto>>
{
    private readonly IProductReadService productReadService;

    public SearchProductsHandler(IProductReadService productReadService)
    {
        this.productReadService = productReadService;
    }

    public async Task<PagedResult<ProductSummaryDto>> HandleAsync(SearchProductsQuery query, CancellationToken ct)
        => await productReadService.SearchAsync(query.Sentence, query.PageNumber, query.PageSize, ct);
}
