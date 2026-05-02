
using e_commerse.Domain.Exceptions.ProductImage;
using SleekCart.Domain.ValueObjects.Product;
using SleekCart.Domain.ValueObjects.ProductImage;

namespace SleekCart.Domain.Entities
{
    public class ProductImage
    {
        public ProductImageId Id { get; private set; }
        public ProductId ProductId { get; private set; }
        public ImageFilePath FilePath { get; private set; }
        public ImageFileName FileName { get; private set; }
        public bool IsMain { get; private set; } = false;
        public DateTime UploadAt { get; private set; }
        public Product? Product { get; set; }

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
            if(IsMain)
                throw new AlreadyImageMainException();

            IsMain = true;
        }

        public void UnsetMain() 
        {
            if(!IsMain)
                throw new AlreadyImageUnMainException();

            IsMain = false;
        }
    }
}
