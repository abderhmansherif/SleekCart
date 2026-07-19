using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Reviews.DeleteReview;

public sealed record DeleteReviewCommand(Guid UserId, Guid ProductId): ICommand;
