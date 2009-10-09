using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcDemo.Controllers;
using MvcDemo.Models;
using MvcDemo.Services;
using NUnit.Framework;
using Rhino.Mocks;

namespace MvcDemo.Tests.Controllers
{
    [TestFixture]
    public class RentControllerTest
    {
        [Test]
        public void TestList_ShouldLoadAllPropertiesAndAssignToViewModel()
        {
            //Arrange
            var service = new FakePropertyService();
            var controller = new RentController(service);
            var properties = new RentalProperty[0];
            service.PropertiesToReturn = properties;

            //Act
            var result = (ViewResult)controller.List();

            //Assert
            Assert.AreEqual(properties, result.ViewData.Model);
        }

        [Test]
        public void TestCreate_ShouldSaveProperty()
        {
            //Arrange
            var service = new FakePropertyService();
            var controller = new RentController(service);
            CreateControllerContextStubFor(controller);    //Must setup ControllerContext, as method under test needs asscess to Controller.Resuest
            
            //Act
            var propertyToCreate = new RentalProperty();
            controller.Create(propertyToCreate);

            //Assert
            Assert.AreEqual(propertyToCreate, service.LastCreatedProperty);
        }

        [Test]
        public void TestCreate_ShouldReturnPropertyPartialView_ForAjaxRequest()
        {
            //Arrange
            var service = new FakePropertyService();
            var controller = new RentController(service);
            CreateControllerContextStubFor(controller);
            controller.Request.Stub(r => r["X-Requested-With"]).Return("XMLHttpRequest");   //make it Ajax request
            
            //Act
            var propertyToCreate = new RentalProperty();
            var result = (PartialViewResult)controller.Create(propertyToCreate);

            //Assert
            Assert.AreEqual("PropertyPartial", result.ViewName);
        }

        [Test]
        public void TestCreate_ShouldRedirectToListView_ForNonAjaxRequest()
        {
            //Arrange
            var service = new FakePropertyService();
            var controller = new RentController(service);
            CreateControllerContextStubFor(controller);
            controller.Request.Stub(r => r["X-Requested-With"]).Return("");   //make it Non-Ajax request

            //Act
            var propertyToCreate = new RentalProperty();
            var result = (RedirectToRouteResult)controller.Create(propertyToCreate);

            //Assert
            Assert.AreEqual("List", result.RouteValues["action"]);
        }

        private static void CreateControllerContextStubFor(ControllerBase controller)
        {
            var stubHttpContext = MockRepository.GenerateStub<HttpContextBase>();
            var stubRequest = MockRepository.GenerateStub<HttpRequestBase>();
            stubHttpContext.Stub(s => s.Request).Return(stubRequest);

            var context = new ControllerContext(stubHttpContext, new RouteData(), controller);
            controller.ControllerContext = context;
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