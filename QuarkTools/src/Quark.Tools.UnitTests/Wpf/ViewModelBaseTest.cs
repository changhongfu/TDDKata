using NUnit.Framework;
using Quark.Tools.Wpf.ViewModel;

namespace Quark.Tools.UnitTests.Wpf
{
    [TestFixture]
    public class ViewModelBaseTest
    {
        [Test]
        public void TestViewModelBase_HasPropertyChangedEvent()
        {
            var model = new TestViewModel();
            model.PropertyChanged += delegate { };
        }

        private class TestViewModel : ViewModelBase
        {
            
        }
    }
}