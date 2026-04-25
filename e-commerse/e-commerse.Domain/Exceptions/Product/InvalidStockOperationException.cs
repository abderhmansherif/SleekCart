using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Product
{
    public class InvalidStockOperationException: ProductException
    {
        public InvalidStockOperationException(string message):
            base(message)
        {
            
        }
    }
}
