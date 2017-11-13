using System.Collections.Generic;
using Pricing.Core.Models;

namespace Pricing.Tests
{
    static class ExchangeRateTestData
    {
        public static ExchangeRate USDToEUR = new ExchangeRate(CurrencyTestData.USD, CurrencyTestData.EUR, 1.11560M);
        public static ExchangeRate EURToUSD = new ExchangeRate(CurrencyTestData.EUR, CurrencyTestData.USD, 0.89638M);
        public static ExchangeRate USDToGBP = new ExchangeRate(CurrencyTestData.USD, CurrencyTestData.GBP, 1.55160M);
        public static ExchangeRate GBPToUSD = new ExchangeRate(CurrencyTestData.GBP, CurrencyTestData.USD, 0.64450M);
        public static ExchangeRate EURToGBP = new ExchangeRate(CurrencyTestData.EUR, CurrencyTestData.GBP, 1.39082M);
        public static ExchangeRate GBPToEUR = new ExchangeRate(CurrencyTestData.GBP, CurrencyTestData.EUR, 0.71900M);

        public static IEnumerable<ExchangeRate> All = new[]
        {
            USDToEUR, EURToUSD, USDToGBP, GBPToUSD, EURToGBP, GBPToEUR
        };
    }
}
