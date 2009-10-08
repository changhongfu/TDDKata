using System.Collections.Generic;
using MvcDemo.Models;

namespace MvcDemo.Services
{
    public interface IPropertyService
    {
        IEnumerable<RentalProperty> GetProperties();

        void CreateProperty(RentalProperty propertyToCreate);
    }
}