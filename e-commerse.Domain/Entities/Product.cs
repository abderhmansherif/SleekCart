using e_commerse.Domain.Exceptions.Product;
using e_commerse.Domain.ValueObjects.Product;
using e_commerse.Domain.ValueObjects.ProductImage;

namespace e_commerse.Domain.Entities
{
    internal class Product
    {
        public ProductId Id { get; private set; }
        public ProductName Name { get; private set; }
        public ProductDescription Description { get; private set; }
        public ProductPrice Price { get; private set; }
        public StockQuantity StockQuantity { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public IReadOnlyCollection<ProductImage> ProductImages => _images;

        private List<ProductImage> _images = new();
        private Product() { }

        internal Product(ProductId id, ProductName name, ProductDescription description, 
                StockQuantity stockQuantity, ProductPrice price)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.StockQuantity = stockQuantity;
            this.CreatedAt = DateTime.UtcNow;
        }

        public void AddImage(ProductImage productImage)
        {
            if (_images.Count >= 10)
                throw new ProductImageLimitExceededException();

            if (!_images.Any())
                productImage.SetMain();

            _images.Add(productImage);
        }

        public void SetImageMain(ProductImageId productImageId)
        {
            if(!_images.Any())
            {
                throw new ProductImageNotFoundException();
            }

            var image = _images.FirstOrDefault(i => i.Id == productImageId);

            if (image is null)
            {
                throw new ProductImageNotFoundException();
            }

            foreach(ProductImage img in _images)
                img.UnsetMain();

            image?.SetMain();
        }

        public void RemoveImage(ProductImageId imageId)
        {
            var image = _images.FirstOrDefault(i => i.Id == imageId);

            if (image is null)
            {
                throw new ProductImageNotFoundException();
            }

            if (image.IsMain && _images.Count > 1)
                throw new CannotRemoveMainImageException();

            _images.Remove(image);
        }

        public void DecreaseStockQuantity(int amount)
        {
            if (amount < 0)
                throw new InvalidStockOperationException("Amount to decrease cannot be negative.");

            if (amount > this.StockQuantity.Value)
                throw new InvalidStockOperationException("Cannot decrease stock quantity below zero.");

            StockQuantity = StockQuantity - amount;
        }

        public void IncreaseStockQuantity(int amount)
        {
            if (amount < 0)
                throw new InvalidStockOperationException("Amount to increase cannot be negative.");

            StockQuantity = StockQuantity + amount;
        }
    }
}
