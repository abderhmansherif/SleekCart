using e_commerse.Domain.Exceptions.Product;

namespace e_commerse.Domain.ValueObjects.Product
{
    public record Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal ammount, string currency)
        {
            if(ammount < 1)
            {
                throw new InvalidProductAmountException();
            }

            if(string.IsNullOrEmpty(currency))
            {
                throw new EmptyProductAmountCurrencyException();
            }

            this.Amount = ammount;
            this.Currency = currency;
        }
    }
}
