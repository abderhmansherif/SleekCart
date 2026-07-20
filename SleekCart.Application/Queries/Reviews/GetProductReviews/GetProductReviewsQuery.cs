using SleekCart.Application.Abstractions.Queries;
using SleekCart.Application.DTOs.Reviews;

namespace SleekCart.Application.Queries.Reviews.GetProductReviews;

public sealed record GetProductReviewsQuery(
    int PageNumber, 
    int PageSize, 
    Guid ProductId
    ): IQuery<List<ReviewDto>>;
