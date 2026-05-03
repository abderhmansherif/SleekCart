using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;
using SleekCart.Domain.Abstractions.Repositories;
using SleekCart.Domain.ValueObjects.Category;
using SleekCart.Domain.ValueObjects.Product;


namespace SleekCart.Application.Commands.Product.ChangeCategory;

public sealed class ChangeCategoryHandler: ICommandHandler<ChangeCategoryCommand>
{
    private readonly IProductRepository productRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly ICategoryRepository categoryRepository;

    public ChangeCategoryHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, 
            ICategoryRepository categoryRepository)
    {
        this.productRepository = productRepository;
        this.unitOfWork = unitOfWork;
        this.categoryRepository = categoryRepository;
    }

    public async Task HandleAsync(ChangeCategoryCommand command, CancellationToken ct)
    {
        var (ProductId, CategoryId) = command;

        var product = await productRepository.GetAsync(new ProductId(ProductId), ct);

        if(product is null)
        {
            throw new NotFoundProductException();
        }

        var category = await categoryRepository.GetAsync(new CategoryId(CategoryId), ct);

        if(category is null)
        {
            throw new NotFoundCategoryException();
        }

        product.ChangeCategory(new CategoryId(CategoryId));

        await productRepository.UpdateAsync(product, ct);

        await unitOfWork.SaveChangesAsync();
    }
}
