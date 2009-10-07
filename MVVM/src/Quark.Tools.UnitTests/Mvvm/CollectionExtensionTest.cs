using System.Windows.Data;
using NUnit.Framework;
using Quark.Tools.Mvvm;
using Quark.Tools.Mvvm.Extensions;

namespace Quark.Tools.UnitTests.Mvvm
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
        }
    }
}