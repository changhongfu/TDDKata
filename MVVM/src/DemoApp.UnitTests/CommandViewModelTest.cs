using System.Windows.Input;
using DemoApp.ViewModels;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class CommandViewModelTest
    {
        [Test]
        public void TestCommandViewModel_HasCommandAndDisplayName()
        {
            var mock = new Mock<ICommand>();
            var model = new CommandViewModel(mock.Object, "a");
            Assert.AreEqual(mock.Object, model.Command);
            Assert.AreEqual("a", model.DisplayName);
        }
    }
}