using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;
using SleekCart.Domain.ValueObjects.ProductImage;

namespace SleekCart.Application.Commands.Product.SetProductImageMain;

public class SetProductImageMainHandler: ICommandHandler<SetProductImageMainCommand>
{
    private readonly IProductRepository productRepository;
    private readonly IUnitOfWork unitOfWork;

    public SetProductImageMainHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        this.productRepository = productRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(SetProductImageMainCommand command, CancellationToken ct)
    {
        var product = await productRepository.GetAsync(command.ProductId, ct);

        if(product is null)
        {
            throw new NotFoundProductException();
        }

        product.SetImageMain(new ProductImageId(command.ImageId));

        await productRepository.UpdateAsync(product, ct);
        await unitOfWork.SaveChangesAsync();
    }
}
