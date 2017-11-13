using System;
using System.Collections.Generic;
using Pricing.Core.Models;

namespace Pricing.Tests
{
    static class TourDepartureTestData
    {
        public static IEnumerable<TourDeparture> TourDepartures = new[]
                                                        {
                                                             new TourDeparture(
                                                                 1,
                                                                 "Agadir - Morocco",
                                                                 new DateTime(2015, 1, 26),
                                                                 new Price(500M, CurrencyTestData.GBP)),
                                                             new TourDeparture(
                                                                 2,
                                                                 "Agadir - Morocco",
                                                                 new DateTime(2015, 11, 26),
                                                                 new Price(500M, CurrencyTestData.GBP)),
                                                             new TourDeparture(
                                                                 3,
                                                                 "Algarve - Portugal",
                                                                 new DateTime(2015, 1, 26),
                                                                 new Price(550M, CurrencyTestData.GBP)),
                                                             new TourDeparture(
                                                                 4,
                                                                 "Algarve - Portugal",
                                                                 new DateTime(2015, 11, 26),
                                                                 new Price(550M, CurrencyTestData.GBP)),
                                                             new TourDeparture(
                                                                 5,
                                                                 "Corfu - Greek Islands",
                                                                 new DateTime(2015, 1, 26),
                                                                 new Price(700M, CurrencyTestData.GBP)),
                                                             new TourDeparture(
                                                                 6,
                                                                 "Corfu - Greek Islands",
                                                                 new DateTime(2015, 11, 26),
                                                                 new Price(700M, CurrencyTestData.GBP)),
                                                         };
    }
}
