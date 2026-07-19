using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;

namespace SleekCart.Application.Commands.Reviews.DeleteReview;

public sealed class DeleteReviewHandler : ICommandHandler<DeleteReviewCommand>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReviewHandler(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
    {
        this._reviewRepository = reviewRepository;
        this._unitOfWork = unitOfWork;
    }
    public async Task HandleAsync(DeleteReviewCommand command, CancellationToken ct)
    {
        var review = await _reviewRepository.GetAsync(userId: command.UserId, productId: command.ProductId, ct);

        if(review is null)
            throw new ReviewNotFoundException();
        
        await _reviewRepository.DeleteAsync(userId: command.UserId, productId: command.ProductId, ct: ct);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}
