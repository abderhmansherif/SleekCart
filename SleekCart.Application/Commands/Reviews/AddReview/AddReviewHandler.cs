using e_commerse.Domain.Abstractions.Factories;
using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;
using SleekCart.Application.Services;

namespace SleekCart.Application.Commands.Reviews.AddReview;

public sealed class AddReviewHandler : ICommandHandler<AddReviewCommand>
{
    private readonly IReviewFactory _reviewFactory;
    private readonly IReviewRepository _reviewRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly IOrderReadService _orderReadService;

    public AddReviewHandler(IReviewFactory reviewFactory, IReviewRepository reviewRepository,
                            IUnitOfWork unitOfWork, IUserRepository userRepository, 
                            IProductRepository productRepository, IOrderReadService orderReadService)
    {
        this._reviewFactory = reviewFactory;
        this._reviewRepository = reviewRepository;
        this._unitOfWork = unitOfWork;
        this._userRepository = userRepository;
        this._productRepository = productRepository;
        this._orderReadService = orderReadService;
    }
    public async Task HandleAsync(AddReviewCommand command, CancellationToken ct)
    {
        var (userId, productId, rating, comment) = command;

        var user = await _userRepository.GetByIdAsync(userId, ct);

        if(user is null)
            throw new NotFoundUserException();

        var Product = await _productRepository.GetAsync(productId, ct);

        if(Product is null)
            throw new NotFoundProductException();

        var existedReview = await _reviewRepository.GetAsync(userId, productId, ct);

        if(existedReview is not null)
        {
            throw new ReviewAlreadyExistsException();
        }

        bool IsVerifiedPurchase = await _orderReadService.HasPurchasedProductAsync(user.Id, Product.Id, ct);

        var review = _reviewFactory.Create(
            userId: user.Id,
            productId: Product.Id,
            comment: comment,
            rating: rating,
            isVerifiedPurchase: IsVerifiedPurchase
        );

        await _reviewRepository.InsertAsync(review, ct);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}
