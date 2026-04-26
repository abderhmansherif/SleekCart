using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Product
{
    public class StockAlreadyReservedException: ProductException
    {
        public StockAlreadyReservedException() : base("Stock is already reserved for this cart.")
        {

        }
    }
}
