namespace Pricing.Core.Models
{
    public class Currency
    {
        public Currency(string code, string symbol, string description)
        {
            Code = code;
            Symbol = symbol;
            Description = description;
        }

        public string Code { get; private set; }
        public string Symbol { get; private set; }
        public string Description { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj is Currency)
            {
                Currency other = (Currency)obj;
                return Code == other.Code;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }

        public override string ToString()
        {
            return Code;
        }
    }
}
