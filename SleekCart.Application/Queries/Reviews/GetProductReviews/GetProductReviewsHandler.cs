using SleekCart.Application.DTOs.Reviews;
using SleekCart.Application.Services;
using SleekCart.Shared.Abstractions.Queries;

namespace SleekCart.Application.Queries.Reviews.GetProductReviews;

public sealed class GetProductReviewsHandler: IQueryHandler<GetProductReviewsQuery, List<ReviewDto>>
{
    private readonly IReviewsReadService _reviewsReadService;

    public GetProductReviewsHandler(IReviewsReadService reviewsReadService)
    {
        this._reviewsReadService = reviewsReadService;
    }

    public async Task<List<ReviewDto>> HandleAsync(GetProductReviewsQuery query, CancellationToken ct)
        => await _reviewsReadService.GetReviewsAsync(
            PageNumber: query.PageNumber,
            PageSize: query.PageSize,
            ProductId: query.ProductId,
            cancellationToken:ct
        );
}