using SleekCart.Application.DTOs.Reviews;

namespace SleekCart.Application.Services;

public interface IReviewsReadService
{
    Task<List<ReviewDto>> GetReviewsAsync(int PageNumber, int PageSize, Guid ProductId, CancellationToken cancellationToken);
}