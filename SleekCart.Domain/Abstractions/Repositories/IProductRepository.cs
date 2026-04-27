using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Product;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(ProductId productId);
        Task InsertAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(ProductId productId);
    }
}
