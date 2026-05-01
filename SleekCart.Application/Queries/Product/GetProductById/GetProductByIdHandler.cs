using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.DTOs.Product;
using SleekCart.Application.Exceptions;
using SleekCart.Application.Mappers.Product;
using SleekCart.Shared.Abstractions.Queries;

namespace SleekCart.Application.Queries.Product.GetProductById;

public sealed class GetProductByIdHandler: IQueryHandler<GetProductByIdQuery, ProductDetailsDto>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }

    public async Task<ProductDetailsDto> HandleAsync(GetProductByIdQuery query, CancellationToken ct)
    {
        var product = await _productRepository.GetAsync(query.ProductId, ct);

        if(product is null)
        {
            throw new NotFoundProductException();
        }

        return product.ToProductDetailsDto();
    }
}
