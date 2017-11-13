namespace Pricing.Core.Models
{
    public class TourDepartureSellingPrice
    {
        public TourDepartureSellingPrice(TourDeparture tourDeparture, Price sellingPrice)
        {
            TourDeparture = tourDeparture;
            SellingPrice = sellingPrice;
        }

        public TourDeparture TourDeparture { get; private set; }
        public Price SellingPrice { get; private set; }
    }
}
