using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Product
{
    public class StockReservationNotFoundException: ProductException
    {
        public StockReservationNotFoundException(): base("Stock reservation not found for the specified cart.")
        {
            
        }
    }
}
