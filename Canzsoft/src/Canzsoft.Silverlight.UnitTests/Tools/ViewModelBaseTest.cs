using Canzsoft.Silverlight.Tools;
using NUnit.Framework;

namespace Canzsoft.Silverlight.UnitTests.Tools
{
    [TestFixture]
    public class ViewModelBaseTest
    {
        [Test]
        public void ChangeProperty_RaisePropertyChangedEvent()
        {
            var viewModel = new FakeViewModel();

            bool eventRaised = false;

            viewModel.PropertyChanged += delegate { eventRaised = true; };

            viewModel.MyProperty = 1;

            Assert.IsTrue(eventRaised);
        }

        private class FakeViewModel : ViewModelBase
        {
            private int _myProperty;

            public int MyProperty
            {
                get { return _myProperty; }
                set
                {
                    _myProperty = value;
                    OnPropertyChanged("MyProperty");
                }
            }
        }
    }
}