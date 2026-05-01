using e_commerse.Domain.Exceptions.Product;
using SleekCart.Domain.ValueObjects.Cart;
using SleekCart.Domain.ValueObjects.Category;
using SleekCart.Domain.ValueObjects.Product;
using SleekCart.Domain.ValueObjects.ProductImage;

namespace SleekCart.Domain.Entities
{
    public class Product
    {
        public ProductId Id { get; private set; }
        public ProductName Name { get; private set; }
        public ProductDescription Description { get; private set; }
        public Money Price { get; private set; }
        public StockQuantity StockQuantity { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public CategoryId? CategoryId { get; private set; }
        public Category? Category { get; private set; } //Nav Property
        public IReadOnlyCollection<ProductImage> ProductImages => _images.AsReadOnly();
        public IReadOnlyCollection<StockReservation> StockReservations => _stockReservations.AsReadOnly();

        private List<ProductImage> _images = new();

        private List<StockReservation> _stockReservations = new();
        private Product() { }

        internal Product(ProductId id, ProductName name, ProductDescription description, 
                StockQuantity stockQuantity, Money money)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Price = money;
            this.StockQuantity = stockQuantity;
            this.CreatedAt = DateTime.UtcNow;
        }

        internal Product(ProductId id, ProductName name, ProductDescription description,
               StockQuantity stockQuantity, Money money, CategoryId categoryId)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Price = money;
            this.CategoryId = categoryId;
            this.StockQuantity = stockQuantity;
            this.CreatedAt = DateTime.UtcNow;
        }

        public void ReserveStock(CartId cartId, int quantity, TimeSpan duration)
        {
            if (quantity <= 0)
                throw new InvalidQuantityException();

            var reservedQuantity = _stockReservations.Where(r => !r.IsExpired).Sum(r => r.Quantity);

            // Must account for active reservations to prevent overselling
            if (StockQuantity.Value - reservedQuantity < quantity)
                throw new InsufficientStockException();

            var reservation = _stockReservations.FirstOrDefault(s => s.CartId == cartId);

            // That't means the reservation need to update the quantity and expiry date, otherwise create a new reservation
            if (reservation is not null)
            {
                _stockReservations.Remove(reservation);
                _stockReservations.Add(new StockReservation(cartId, quantity, duration));
            }
            else 
            {
                _stockReservations.Add(new StockReservation(cartId, quantity, duration));
            }
        }

        public void ConfirmReservation(CartId cartId)
        {
            var reservation = _stockReservations.FirstOrDefault(s => s.CartId == cartId);

            if(reservation is null)
            {
                throw new StockReservationNotFoundException();
            }

            if (reservation.IsExpired)
            {
                ReleaseReservation(cartId);

                throw new StockReservationExpiredException();
            }

            DecreaseStockQuantity(reservation.Quantity);

            _stockReservations.Remove(reservation);
        }

        public void ReleaseReservation(CartId cartId)
        {
            var reservation = _stockReservations.FirstOrDefault(s => s.CartId == cartId && s.IsExpired);

            if (reservation is null)
            {
                throw new StockReservationNotFoundException();
            }

            _stockReservations.Remove(reservation);
        }

        public void ChangeCategory(CategoryId newCategoryId)
        {
            if(CategoryId == newCategoryId)
            {
                throw new SameCategoryException();
            }

            this.CategoryId = newCategoryId;
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
            if (amount <= 0)
                throw new InvalidStockOperationException("Amount to decrease cannot be negative.");

            if (amount > this.StockQuantity.Value)
                throw new InvalidStockOperationException("Cannot decrease stock quantity below zero.");

            StockQuantity = StockQuantity - amount;
        }

        public void IncreaseStockQuantity(int amount)
        {
            if (amount <= 0)
                throw new InvalidStockOperationException("Amount to increase cannot be negative.");

            StockQuantity = StockQuantity + amount;
        }
    }
}
