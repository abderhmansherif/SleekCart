using SleekCart.Application.DTOs.Product;
using SleekCart.Domain.ValueObjects.Product;

namespace SleekCart.Application.Mappers.Product;

public static class MoneyMapper
{
    public static MoneyDto ToMoneyDto(this Money money)
    {
        return new MoneyDto
        {
            Amount = money.Amount,
            Currency = money.Currency  
        };
    }
}
