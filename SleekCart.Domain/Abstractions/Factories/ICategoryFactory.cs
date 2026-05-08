using SleekCart.Domain.Entities;

namespace SleekCart.Domain.Abstractions.Factories;

public interface ICategoryFactory
{
    Category Create(string CategoryName);
}
