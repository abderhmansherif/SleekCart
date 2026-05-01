using SleekCart.Application.DTOs.Product;

namespace SleekCart.Application.Mappers.Product;

public static class ProductDetailsMapper
{
    public static ProductDetailsDto ToProductDetailsDto(this Domain.Entities.Product product)
        => new ProductDetailsDto
            {
                Id = product.Id,
                Name = product.Name,
                Descreption = product.Description,
                StockQuantity = product.StockQuantity,
                Category = product.Category?.Name ?? "",
                Price = product.Price.ToMoneyDto(),
                Images = product.ProductImages.Select(pi => pi.ToImageDTo()).ToList()
            };
    
}
