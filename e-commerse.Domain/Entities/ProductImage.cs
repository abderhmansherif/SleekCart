using e_commerse.Domain.ValueObjects.Product;
using e_commerse.Domain.ValueObjects.ProductImage;

namespace e_commerse.Domain.Entities
{
    public class ProductImage
    {
        public ProductImageId Id { get; private set; }
        public ProductId ProductId { get; private set; }
        public ImageFilePath FilePath { get; private set; }
        public ImageFileName FileName { get; private set; }
        public bool IsMain { get; private set; } = false;
        public DateTime UploadAt { get; private set; }

        public ProductImage(ProductImageId id, ProductId productId, ImageFilePath filePath, 
            ImageFileName fileName)
        {
            Id = id;
            ProductId = productId;
            FilePath = filePath;
            FileName = fileName;
            UploadAt = DateTime.UtcNow;
        }

        public void SetMain()
        {
            IsMain = true;
        }

        public void UnsetMain() 
        {
            IsMain = false;
        }
    }
}
