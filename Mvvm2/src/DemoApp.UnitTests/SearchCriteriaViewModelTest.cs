using System.Linq;
using DemoApp.ViewModels;
using NUnit.Framework;
using Quark.Tools.Ioc;
using Quark.Tools.Testing.Extensions;
using Quark.Tools.Wpf.Extension;

namespace DemoApp.UnitTests
{
    [TestFixture]
    public class SearchCriteriaViewModelTest : BaseViewModelTest<SearchCriteriaViewModel>
    {
        [Test]
        public void HasListOfAvailableProperties()
        {
            var model = CreateViewModel();
            Assert.IsNotNull(model.AvailableProperties);
        }

        [Test]
        public void SetBoundType_ShouldFillAvailableProperties()
        {
            var model = CreateViewModel();

            model.SetBoundType<TestClass>();

            var properties = model.AvailableProperties.ToArray();
            Assert.AreEqual("Property1", properties[0].Name);
            Assert.AreEqual("Property2", properties[1].Name);
        }

        [Test]
        public void HasListOfAvailableConditions()
        {
            var model = CreateViewModel();
            Assert.IsNotNull(model.AvailableConditions);
        }

        [Test]
        public void ChangeAvailableConditions_ShouldRaisePropertyChangedEvent()
        {
            var model = CreateViewModel();
            model.AssertEventWasRaised("AvailableConditions", o => o.AvailableConditions = new string[0]);
        }

        [Test]
        public void HasCurrentProperty_AfterSetBoundType()
        {
            var model = CreateViewModel();

            model.SetBoundType<TestClass>();

            Assert.IsNotNull(model.CurrentProperty);
        }

        protected override SearchCriteriaViewModel CreateViewModel(IIocContainer iocContainer)
        {
            return new SearchCriteriaViewModel(iocContainer);
        }

        private class TestClass
        {
            public int Property1 { get; set; }
            public string Property2 { get; set; }
        }
    }
}