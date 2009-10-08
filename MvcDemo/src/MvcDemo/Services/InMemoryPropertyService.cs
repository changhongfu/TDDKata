using System.Collections.Generic;
using System.Linq;
using MvcDemo.Models;

namespace MvcDemo.Services
{
    public class InMemoryPropertyService : IPropertyService
    {
        #region List of InMemory Data
        private static readonly List<RentalProperty> Properties = new List<RentalProperty>
            {
                new RentalProperty
                   {
                       NumberBedrooms = 2,
                       NumberBathrooms = 1,
                       NumberCarSpaces = 1,
                       Rent = 390.00m,
                       AddressStreet = "11 8 Brand Street",
                       AddressSuburb = "Artarmon",
                       Contact = "Scott Dolce",
                       ContactPhone = "04 99818891",
                       Summary = "Spacious Living",
                       Description = "Spacious two bedroom apartment with a huge entertaining balcony for outdoor living. Located on the top floor Combined lounge and dining room Large kitchen with dishwasher Built-in robe in main bedroom Internal la...",
                       ImageUrl1 = "../../Images/property1-1.JPG",
                       ImageUrl2 = "../../Images/property1-2.JPG",
                   },
                   new RentalProperty
                   {
                       NumberBedrooms = 2,
                       NumberBathrooms = 1,
                       NumberCarSpaces = 1,
                       Rent = 420.00m,
                       AddressStreet = "2/21 Eric Road",
                       AddressSuburb = "Artarmon",
                       Contact = "Damien Cohen ",
                       ContactPhone = "04 75648921",
                       Summary = "ULTRA MODERN ONE BEDROOM UNIT IN A CONVENIENT LOCATION!!!",
                       Description = "Newly completed one bedroom security apartment located in the heart of Artarmon Features include: - Large bedroom with built-in wardrobes and balcony off bedroom - Beautiful, mode...",
                       ImageUrl1 = "../../Images/property2-1.JPG",
                       ImageUrl2 = "../../Images/property2-2.JPG",
                   },
                   new RentalProperty
                   {
                       NumberBedrooms = 2,
                       NumberBathrooms = 1,
                       NumberCarSpaces = 1,
                       Rent = 420.00m,
                       AddressStreet = "19/2 Barton Road",
                       AddressSuburb = "Artarmon",
                       Contact = "Nadim Wehbe ",
                       ContactPhone = "04 88755623",
                       Summary = "Only a short walk to Artarmon station, shops and Public School",
                       Description = "Spacious two bedroom apartment perfectly positioned to make modern living a breeze. The apartment features: - spacious combined lounge and dining area with balcony - neat and ti...",
                       ImageUrl1 = "../../Images/property3-1.JPG",
                       ImageUrl2 = "../../Images/property3-2.JPG",
                   },
                   new RentalProperty
                   {
                       NumberBedrooms = 2,
                       NumberBathrooms = 1,
                       NumberCarSpaces = 1,
                       Rent = 420.00m,
                       AddressStreet = "14/85-91 Hampden Rd",
                       AddressSuburb = "Artarmon",
                       Contact = "Michelle Landry",
                       ContactPhone = "04 74523511",
                       Summary = "Large Apartment in a Sought After Block in the Heart of Artarmon",
                       Description = "Large Apartment in a Sought After Block in the Heart of Artarmon Features Include: - Large combined lounge/dining area leading on to a good sized balcony - Modern electric k...",
                       ImageUrl1 = "../../Images/property4-1.JPG",
                       ImageUrl2 = "../../Images/property4-2.JPG",
                   }
            };
        #endregion

        public IEnumerable<RentalProperty> GetProperties()
        {
            return Properties.AsEnumerable();
        }

        public void CreateProperty(RentalProperty propertyToCreate)
        {
            Properties.Add(propertyToCreate);
        }
    }
}