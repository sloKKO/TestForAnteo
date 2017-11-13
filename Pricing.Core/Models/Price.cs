namespace Pricing.Core.Models
{
    public class Price
    {
        public Price(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public decimal Amount { get;  set; }
        public Currency Currency { get;  set; }

        public override string ToString()
        {
            return Currency.Symbol + Amount.ToString("0.00");
        }

        public override bool Equals(object obj)
        {
            if (obj is Price)
            {
                Price other = (Price)obj;
                return Amount == other.Amount && Currency == other.Currency;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + Amount.GetHashCode();
                hash = hash * 23 + Currency.GetHashCode();
                return hash;
            }
        }
    }
}
