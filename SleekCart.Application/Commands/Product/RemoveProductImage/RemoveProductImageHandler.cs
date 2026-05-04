using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;

namespace SleekCart.Application.Commands.Product.RemoveProductImage;

public sealed class RemoveProductImageHandler: ICommandHandler<RemoveProductImageCommand>
{
    private readonly IProductRepository productRepository;
    private readonly IUnitOfWork unitOfWork;

    public RemoveProductImageHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        this.productRepository = productRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(RemoveProductImageCommand command, CancellationToken ct)
    {
        var product = await productRepository.GetAsync(command.ProductId, ct);

        if(product is null)
        {
            throw new NotFoundProductException();
        }

        product.RemoveImage(command.ImageId);

        await productRepository.UpdateAsync(product, ct);
        await unitOfWork.SaveChangesAsync();
    }
}
