namespace MvcDemo.Models
{
    public class RentalProperty
    {
        public int NumberBedrooms { get; set; }
        public int NumberBathrooms { get; set; }
        public int NumberCarSpaces { get; set; }

        public decimal Rent { get; set; }

        public string AddressStreet { get; set; }
        public string AddressSuburb { get; set; }

        public string Summary { get; set; }
        public string Description { get; set; }

        public string Contact { get; set; }
        public string ContactPhone { get; set; }

        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
    }
}