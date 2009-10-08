using System.Collections.Generic;
using System.Web.Mvc;
using MvcDemo.Controllers;
using MvcDemo.Models;
using MvcDemo.Services;
using NUnit.Framework;

namespace MvcDemo.Tests.Controllers
{
    [TestFixture]
    public class RentControllerTest
    {
        [Test]
        public void TestList_ShouldAssignPropertiesToViewModel()
        {
            FakePropertyService service = new FakePropertyService();
            var controller = new RentController(service);

            var properties = new RentalProperty[0];
            service.PropertiesToReturn = properties;

            var result = (ViewResult)controller.List();

            Assert.AreEqual(properties, result.ViewData.Model);
        }

        [Test]
        public void TestCreate_ShouldSaveProperty()
        {
            FakePropertyService service = new FakePropertyService();
            var controller = new RentController(service);
            var propertyToCreate = new RentalProperty();

            controller.Create(propertyToCreate);

            Assert.AreEqual(propertyToCreate, service.LastCreatedProperty);
        }

        private class FakePropertyService : IPropertyService
        {
            public IEnumerable<RentalProperty> PropertiesToReturn { get; set; }
            public RentalProperty LastCreatedProperty { get; set; }

            public IEnumerable<RentalProperty> GetProperties()
            {
                return PropertiesToReturn;
            }

            public void CreateProperty(RentalProperty propertyToCreate)
            {
                LastCreatedProperty = propertyToCreate;
            }
        }
    }
}