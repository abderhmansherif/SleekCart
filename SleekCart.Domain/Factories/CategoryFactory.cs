using SleekCart.Domain.Abstractions.Factories;
using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Category;

namespace SleekCart.Domain.Factories;

public sealed class CategoryFactory : ICategoryFactory
{
    public Category Create(string CategoryName)
        => new Category(
            id: Guid.NewGuid(),
            name: new CategoryName(CategoryName)
        );
}
