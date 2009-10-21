using System.Windows.Data;
using Moq;
using NUnit.Framework;
using Quark.Tools.Ioc;
using Quark.Tools.Wpf.Extension;
using Quark.Tools.Wpf.ViewModel;

namespace Quark.Tools.UnitTests.Wpf
{
    [TestFixture]
    public class CollectionExtensionTest
    {
        [Test]
        public void SetCurrentView_ShouldFindDefaultViewForACollection_AndSetCurrentItem()
        {
            var models = new[] { new TestViewModel(), new TestViewModel() };
            models.SetCurrentView(models[1]);

            var collectionView = CollectionViewSource.GetDefaultView(models);
            Assert.AreEqual(models[1], collectionView.CurrentItem);
        }

        private class TestViewModel : ViewModelBase
        {
            public TestViewModel() : base(new Mock<IIocContainer>().Object)
            {
            }
        }
    }
}