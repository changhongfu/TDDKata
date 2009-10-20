using DemoApp.ViewModels;
using NUnit.Framework;

namespace DemoApp.UnitTests
{
    [TestFixture]
    public class ShellViewModelTest
    {
        [Test]
        public void WorkspacesFirstElement_ShouldBe_HomeViewModel()
        {
            var model = new ShellViewModel();
            var homeViewModel = model.Workspaces[0];
            Assert.AreEqual(typeof(HomeViewModel), homeViewModel.GetType());
        }
    }
}