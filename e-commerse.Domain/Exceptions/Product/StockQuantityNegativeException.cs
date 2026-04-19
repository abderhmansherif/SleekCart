using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Product
{
    public class StockQuantityNegativeException: ProductException
    {
        public StockQuantityNegativeException(): base("Stock quantity cannot be negative.")
        {
            
        }
    }
}
