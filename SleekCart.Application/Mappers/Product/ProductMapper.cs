using SleekCart.Application.DTOs.Product;

namespace SleekCart.Application.Mappers.Product;

public static class ProductMapper
{
    public static ProductSummaryDto ToDTO(this Domain.Entities.Product product)
    {
        return new ProductSummaryDto
        {
            Id = product.Id.Value,
            Name = product.Name.Value,
            Price = product.Price.ToMoneyDto(),
            Category = product.Category?.Name?? null!,
            ProductMainImage = product.ProductImages.Where(x => x.IsMain).Select(x => new ProductImageDto
            {
                Id = x.Id,
                FilePath = x.FilePath.Value,
                IsMain = x.IsMain
            })
            .FirstOrDefault()!
        };
    }
}
