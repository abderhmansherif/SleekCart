using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Reviews.AddReview;

public sealed record AddReviewCommand(
    Guid UserId,
    Guid ProductId,
    decimal Rating,
    string Comment ):ICommand;
