using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;
using SleekCart.Application.Services;
using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.ProductImage;

namespace SleekCart.Application.Commands.Product.AddProductImage;

public sealed class AddProductImageHandler: ICommandHandler<AddProductImageCommand>
{
    private readonly IProductRepository productRepository;
    private readonly IStorageService storageService;
    private readonly IUnitOfWork unitOfWork;

    public AddProductImageHandler(IProductRepository productRepository, IStorageService storageService,
                         IUnitOfWork unitOfWork)
    {
        this.productRepository = productRepository;
        this.storageService = storageService;
        this.unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(AddProductImageCommand command, CancellationToken ct)
    {
        var product = await productRepository.GetAsync(command.ProductId, ct);

        if(product is null)
        {
            throw new NotFoundProductException();
        }

        string imageUrl = await storageService.UploadAsync(command.Image.FileName, command.Image.ContentType, command.Image.Stream);

        try
        {
            var image = new ProductImage(
                id: new ProductImageId(Guid.NewGuid()),
                productId: product.Id,
                fileName: new ImageFileName(command.Image.FileName),
                filePath: new ImageFilePath(imageUrl)
            );

            product.AddImage(image);

            await productRepository.UpdateAsync(product, ct);

            await unitOfWork.SaveChangesAsync();   
        }
        catch
        {
            await storageService.DeleteAsync(imageUrl);
            throw;
        }
    }
}
