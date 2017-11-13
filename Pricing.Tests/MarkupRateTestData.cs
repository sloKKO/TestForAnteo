using System;
using System.Collections.Generic;
using Pricing.Core.Models;

namespace Pricing.Tests
{
    static class MarkupRateTestData
    {
        public static readonly IEnumerable<MarkupRate> All = new[]
        {
            new MarkupRate(new DateTime(2015, 1, 1), new DateTime(2015, 6, 30), CurrencyTestData.USD, 20),
            new MarkupRate(new DateTime(2015, 7, 1), new DateTime(2015, 12, 31), CurrencyTestData.USD, 25),
            new MarkupRate(new DateTime(2015, 1, 1), new DateTime(2015, 6, 30), CurrencyTestData.GBP, 15),
            new MarkupRate(new DateTime(2015, 7, 1), new DateTime(2015, 12, 31), CurrencyTestData.GBP, 18),
            new MarkupRate(new DateTime(2015, 1, 1), new DateTime(2015, 6, 30), CurrencyTestData.EUR, 30),
            new MarkupRate(new DateTime(2015, 7, 1), new DateTime(2015, 12, 31), CurrencyTestData.EUR, 35),
        };
    }
}
