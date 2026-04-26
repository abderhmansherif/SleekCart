
using e_commerse.Domain.Abstractions.Factories;
using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Category;
using SleekCart.Domain.ValueObjects.Product;

namespace e_commerse.Domain.Factories
{
    public class ProductFactory : IProductFactory
    {
        public Product CreateDefault(ProductId id, ProductName name, ProductDescription description, 
            StockQuantity stockQuantity, Money amount)

            => new Product(id, name, description, stockQuantity, amount);

        public Product CreateWithCategory(ProductId id, ProductName name, ProductDescription description, 
            StockQuantity stockQuantity, Money money, CategoryId categoryId)

            => new Product(id, name, description, stockQuantity, money, categoryId);
    }
}
