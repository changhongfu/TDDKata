using DemoApp.ViewModels;
using NUnit.Framework;

namespace DemoApp.UnitTests
{
    [TestFixture]
    public class HomeViewModelTest
    {
        [Test]
        public void DisplayName_ShouldBe_Home()
        {
            var model = new HomeViewModel();
            var displayName = model.DisplayName;
            Assert.AreEqual("Home", displayName);
        }

        [Test]
        public void HomeViewModel_IsNotCloseable()
        {
            var model = new HomeViewModel();
            bool canClose = model.IsCloseable;
            Assert.IsFalse(canClose);
        }
    }
}