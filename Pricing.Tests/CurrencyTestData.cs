using System.Collections.Generic;
using Pricing.Core.Models;

namespace Pricing.Tests
{
    static class CurrencyTestData
    {
        public static Currency USD = new Currency("USD", "$", "US dollar");
        public static Currency EUR = new Currency("EUR", "€", "Euro");
        public static Currency GBP = new Currency("GBP", "£", "Pound sterling");

        public static IEnumerable<Currency> All = new[] { USD, EUR, GBP };
    }
}
