using SleekCart.Application.Abstractions.Queries;
using SleekCart.Application.Common.DTOs;
using SleekCart.Application.DTOs.Product;

namespace SleekCart.Application.Queries.Product.SearchProducts;

public sealed record SearchProductsQuery(string Sentence, int PageNumber, int PageSize) :IQuery<PagedResult<ProductSummaryDto>>;
