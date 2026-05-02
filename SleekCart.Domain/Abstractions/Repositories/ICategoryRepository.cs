using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Category;

namespace SleekCart.Domain.Abstractions.Repositories;

public interface ICategoryRepository
{
    Task InsertAsync(Category category, CancellationToken ct);
    Task UpdateAsync(Category category, CancellationToken ct);
    Task DeleteAsync(Category category, CancellationToken ct);
    Task<Category> GetAsync(CategoryId categoryId, CancellationToken ct);
}
