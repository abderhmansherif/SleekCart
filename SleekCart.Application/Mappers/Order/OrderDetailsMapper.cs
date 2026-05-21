using SleekCart.Application.DTOs.Order;

namespace SleekCart.Application.Mappers.Order;

public static class OrderDetailsMapper
{
    public static OrderDetailsDto ToDetails(this Domain.Entities.Order order)
    {
        return new OrderDetailsDto
        {
            OrderId = order.Id,
            UserId = order.UserId,
            Status = order.Status.ToString(),
            Currency = order.Currency.Value,
            SubTotal = order.SubTotal.Amount,
            Total = order.Total.Amount,
            Discount = order.Discount?.Amount?? 0,
            ShippingAddress = new ShippingAddressDto
            {
                City = order.ShippingAddress.City,
                Country = order.ShippingAddress.Country,
                Street = order.ShippingAddress.Street,
                Note = order.ShippingAddress.Note
            },
            Items = order.Items.Select(x => new OrderItemDto
            {
                ProductId = x.ProductId,
                ProductName = x.Product?.Name,
                ProductMainImageUrl = x.Product?.ProductImages?.FirstOrDefault(im => im.IsMain)?.FilePath ?? string.Empty,
                Quantity = x.Quantity,
                Price = new DTOs.Product.MoneyDto
                {
                    Amount = x.Price.Amount,
                    Currency = x.Price.Currency
                },
                Total = x.Total
            }).ToList(),

            History = order.History.Select(h => new OrderTimeLine
            {
                Status = h.Status.ToString(),
                At = h.ChangedAt,
                Note = h.Note
            }).ToList(),

            CreatedAt = order.CreatedAt,
            CouponId = order.CouponId.Value
        };
    }
}
