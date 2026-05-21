using e_commerse.Domain.Exceptions.Cart;
using e_commerse.Domain.Exceptions.Product;

namespace SleekCart.Domain.ValueObjects.Product
{
    public record Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal ammount, string currency)
        {
            if(ammount < 0)
            {
                throw new InvalidProductAmountException();
            }

            if(string.IsNullOrEmpty(currency))
            {
                throw new EmptyProductAmountCurrencyException();
            }

            this.Amount = ammount;
            this.Currency = currency.ToUpper();
        }

        public static Money Zero(string currency) => new Money(0, currency);
        public Money Subtract(Money other)
        {
            if(this.Currency != other.Currency)
            {
                throw new CurrencyMismatchException();
            }

            return new Money(Amount - other.Amount, Currency);
        }
    }
}
