using SleekCart.Application.DTOs.Cart;

namespace SleekCart.Application.Mappers.Cart;

public static class CartMapper
{
    public static CartDto ToDTO(this Domain.Entities.Cart cart)
    {
        return new CartDto
        {
            CartId = cart.Id,
            Currency = cart.Currency?.Value??"",
            Total = cart.Total?.Amount?? 0,
            Items = cart.Items.Select(i => new CartItemDto
            {
                ProductId = i.ProductId,
                ProductName = i.Product?.Name??"",
                MainImageUrl = i.Product?.ProductImages.FirstOrDefault(i => i.IsMain)?.FilePath??"",
                Currency = i.Price.Currency,
                Price = i.Price.Amount,
                Quantity = i.Quantity,
                Total = i.Total
            }).ToList(),
        };
    }
}
