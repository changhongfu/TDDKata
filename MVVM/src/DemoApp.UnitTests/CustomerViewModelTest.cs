using System;
using System.Linq;
using DemoApp.Models;
using DemoApp.Services;
using DemoApp.ViewModels;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class CustomerViewModelTest
    {
        [Test]
        public void TestConstructor_ShouldCreateCustomer()
        {
            var model = new CustomerViewModel();
            Assert.AreEqual(String.Empty, model.FirstName);
            Assert.AreEqual(String.Empty, model.LastName);
            Assert.AreEqual(String.Empty, model.Email);
        }

        [Test]
        public void TestConstructor_ShouldCreateSaveCommand()
        {
            var model = new CustomerViewModel();
            Assert.IsNotNull(model.SaveCommand);            
        }

        [Test]
        public void TestCustomerTypes_ShouldReturnAllCustomerTypesAsString()
        {
            var model = new CustomerViewModel();
            var customerTypes = model.CustomerTypes.ToArray();
            Assert.AreEqual("Person", customerTypes[0]);
            Assert.AreEqual("Company", customerTypes[1]);
        }

        [Test]
        public void TestSaveCommand_SaveCustomer_WhenExecute()
        {
            var mock = new Mock<ICustomerService>();
            var model = new CustomerViewModel(mock.Object);
            model.SaveCommand.Execute(null);

            mock.Verify(s => s.SaveCustmer(model.Customer));
        }
    }
}