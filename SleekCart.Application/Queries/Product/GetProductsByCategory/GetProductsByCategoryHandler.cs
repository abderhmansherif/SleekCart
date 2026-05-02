using SleekCart.Application.Common.DTOs;
using SleekCart.Application.DTOs.Product;
using SleekCart.Application.Exceptions;
using SleekCart.Application.Services;
using SleekCart.Domain.Abstractions.Repositories;
using SleekCart.Shared.Abstractions.Queries;

namespace SleekCart.Application.Queries.Product.GetProductsByCategory;

public sealed class GetProductsByCategoryHandler: IQueryHandler<GetProductsByCategoryQuery, PagedResult<ProductSummaryDto>>
{
    private readonly IProductReadService _productReadService;
    private readonly ICategoryRepository _categoryRepository;

    public GetProductsByCategoryHandler(IProductReadService productReadService, 
                                ICategoryRepository categoryRepository)
    {
        this._productReadService = productReadService;
        this._categoryRepository = categoryRepository;
    }

    public async Task<PagedResult<ProductSummaryDto>> HandleAsync(GetProductsByCategoryQuery query, CancellationToken ct)
    {
        var category = await _categoryRepository.GetAsync(query.CategoryId, ct);

        if(category is null)
        {
            throw new NotFoundCategoryException();
        }

        var products = await _productReadService.GetByCategoryIdAsync(category.Id, query.PageNumber, query.PageSize, ct);

        return products;
    }
}
