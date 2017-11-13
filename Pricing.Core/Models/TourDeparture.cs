using System;

namespace Pricing.Core.Models
{
    public class TourDeparture
    {
        public TourDeparture(int id, string description, DateTime departureDate, Price localCost)
        {
            Id = id;
            Description = description;
            DepartureDate = departureDate;
            LocalCost = localCost;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public DateTime DepartureDate { get; private set; }
        public Price LocalCost { get; private set; }
    }
}
