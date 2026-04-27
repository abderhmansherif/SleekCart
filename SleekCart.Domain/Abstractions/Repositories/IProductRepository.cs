using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Product;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(ProductId productId, CancellationToken ct);
        Task InsertAsync(Product product, CancellationToken ct);
        Task UpdateAsync(Product product, CancellationToken ct);
        Task DeleteAsync(ProductId productId, CancellationToken ct);
    }
}
