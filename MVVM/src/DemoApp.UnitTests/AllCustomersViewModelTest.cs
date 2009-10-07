using DemoApp.Models;
using DemoApp.Services;
using DemoApp.ViewModels;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class AllCustomersViewModelTest
    {
        [Test]
        public void ShouldLoadAllCustomers_WhenCreated()
        {
            var mock = new Mock<ICustomerService>();
            var customers = new[] {new Customer()};
            mock.Setup(m => m.GetAllCustomers()).Returns(customers);

            var model = new AllCustomersViewModel(mock.Object);

            Assert.AreEqual(customers[0], model.Customers[0].Customer);
        }

        [Test]
        public void DisplayNameShouldBeAllCustomers()
        {
            var model = new AllCustomersViewModel();

            Assert.AreEqual("All Customers", model.DisplayName);
        }

        [Test]
        public void HasSelectCustomerCommand()
        {
            var model = new AllCustomersViewModel();
            Assert.IsNotNull(model.SelectCustomerCommand);
        }

        [Test]
        public void ExecuteSelectCustomerCommand_ShouldRaiseCustomerSelectedEvent()
        {
            var model = new AllCustomersViewModel();
            bool raised = false;
            model.CustomerSelected += delegate { raised = true; };

            model.SelectCustomerCommand.Execute(new CustomerViewModel());

            Assert.IsTrue(raised);
        }

        [Test]
        public void CustomerSelectedEvent_ShouldHaveSelectedCustomerInEventArgs()
        {
            var model = new AllCustomersViewModel();
            Customer selectedCustomer = null;
            model.CustomerSelected += (sender, args) => selectedCustomer = args.Item;

            var customerViewModel = new CustomerViewModel(new Customer());
            model.SelectCustomerCommand.Execute(customerViewModel);

            Assert.AreEqual(customerViewModel.Customer, selectedCustomer);
        }
    }
}