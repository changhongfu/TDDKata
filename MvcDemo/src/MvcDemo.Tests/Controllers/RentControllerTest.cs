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
            var service = new FakePropertyService();
            var controller = new RentController(service);

            var properties = new RentalProperty[0];
            service.PropertiesToReturn = properties;

            var result = (ViewResult)controller.List();

            Assert.AreEqual(properties, result.ViewData.Model);
        }

        [Test]
        public void TestCreate_ShouldSaveProperty()
        {
            var service = new FakePropertyService();
            var controller = new RentController(service);
            var propertyToCreate = new RentalProperty();

            var stubHttpContext = MockRepository.GenerateStub<HttpContextBase>();
            var stubRequest = MockRepository.GenerateStub<HttpRequestBase>();
            stubHttpContext.Stub(s => s.Request).Return(stubRequest);
           // stubRequest.Stub(r => r["X-Requested-With"]).Return("XMLHttpRequest");
            var context = new ControllerContext(stubHttpContext, new RouteData(), controller);
            controller.ControllerContext = context;

            controller.Create(propertyToCreate);

            Assert.AreEqual(propertyToCreate, service.LastCreatedProperty);
        }

        [Test]
        public void TestCreate_ShouldReturnPropertyPartialView_ForAjaxRequest()
        {
            var service = new FakePropertyService();
            var controller = new RentController(service);
            var propertyToCreate = new RentalProperty();

            var stubHttpContext = MockRepository.GenerateStub<HttpContextBase>();
            var stubRequest = MockRepository.GenerateStub<HttpRequestBase>();
            stubHttpContext.Stub(s => s.Request).Return(stubRequest);
            stubRequest.Stub(r => r["X-Requested-With"]).Return("XMLHttpRequest");
            var context = new ControllerContext(stubHttpContext, new RouteData(), controller);
            controller.ControllerContext = context;

            var result = (PartialViewResult)controller.Create(propertyToCreate);

            Assert.AreEqual("PropertyPartial", result.ViewName);
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