using SleekCart.Application.DTOs.Product;
using SleekCart.Domain.Entities;

namespace SleekCart.Application.Mappers.Product;

public static class ProductImageDtoMapper
{
    public static ProductImageDto ToImageDTo(this ProductImage image)
        => new ProductImageDto
        {
            Id = image.Id,
            FilePath = image.FilePath,
            IsMain = image.IsMain
        };
}
