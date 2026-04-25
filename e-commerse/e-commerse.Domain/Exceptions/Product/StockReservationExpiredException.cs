using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Product
{
    public class StockReservationExpiredException: ProductException
    {
        public StockReservationExpiredException(): base("The stock reservation has expired.")
        {
            
        }
    }
}
