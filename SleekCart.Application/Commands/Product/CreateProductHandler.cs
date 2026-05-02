using e_commerse.Domain.Abstractions.Factories;
using e_commerse.Domain.Abstractions.Repositories;
using FluentValidation;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;
using SleekCart.Application.Services;
using SleekCart.Domain.Entities;

namespace SleekCart.Application.Commands.Product;

public sealed class CreateProductHandler : ICommandHandler<CreateProductCommand>
{
    private readonly IProductFactory _productFactory;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStorageService _storageService;
    private readonly IValidator<CreateProductCommand> _validator;

    public CreateProductHandler(IProductFactory productFactory, IProductRepository productRepository,
                                IUnitOfWork unitOfWork, IStorageService storageService,
                                IValidator<CreateProductCommand> validator)
    {
        this._productFactory = productFactory;
        this._productRepository = productRepository;
        this._unitOfWork = unitOfWork;
        this._storageService = storageService;
        this._validator = validator;
    }

    public async Task HandleAsync(CreateProductCommand command, CancellationToken ct)
    {
        var result = _validator.Validate(command);

        if(!result.IsValid)
            throw new ValidationFailedException(result.Errors);

        var ProductExists = await _productRepository.GetByNameAsync(command.ProductName, ct);
        
        // Idempotency
        if(ProductExists is not null)
        {
            throw new AlreadyProductExistException();
        }

        var productId = Guid.NewGuid();

        List<ProductImage> productImages = new();
        List<string> uploadedUrls = new();

        try
        {
            foreach (var image in command.Images)
            {
                var url = await _storageService.UploadAsync(image.FileName, image.ContentType, image.Stream);
                uploadedUrls.Add(url);
                productImages.Add(new ProductImage(Guid.NewGuid(), productId, url, image.FileName));
            }
        }
        catch
        {
            foreach (var image in uploadedUrls)
                await _storageService.DeleteAsync(image);

            throw;
        }
        
        var newProduct = command.CategoryId == null ? 
                        _productFactory.CreateDefault(
                            id: productId,
                            name: command.ProductName,
                            description: command.ProductDescription,
                            stockQuantity: command.StockQuantity,
                            money: command.Price
                        ) :
                        _productFactory.CreateWithCategory(
                            id: productId,
                            name: command.ProductName,
                            description: command.ProductDescription,
                            stockQuantity: command.StockQuantity,
                            money: command.Price,
                            categoryId: command.CategoryId
                        );

        foreach (var image in productImages)
        {
            newProduct.AddImage(image);
        }

        await _productRepository.InsertAsync(newProduct, ct);
        await _unitOfWork.SaveChangesAsync();
    }
}
