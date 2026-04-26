using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Category;
using SleekCart.Domain.ValueObjects.Product;

namespace e_commerse.Domain.Abstractions.Factories
{
    public interface IProductFactory
    {
        public Product CreateDefault(ProductId id, ProductName name, ProductDescription description, 
            StockQuantity stockQuantity, Money money);
        public Product CreateWithCategory(ProductId id, ProductName name, ProductDescription description,
            StockQuantity stockQuantity, Money money, CategoryId categoryId);
    }
}
