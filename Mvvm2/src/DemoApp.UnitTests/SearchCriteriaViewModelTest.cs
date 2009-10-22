using System.Linq;
using System.Windows.Input;
using DemoApp.Messages;
using DemoApp.ViewModels;
using Moq;
using NUnit.Framework;
using Quark.Tools.Ioc;
using Quark.Tools.Testing.Extensions;
using Quark.Tools.Wpf.Events;
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
            model.AssertEventWasRaised("AvailableConditions", o => o.AvailableConditions = null);
        }

        [Test]
        public void HasCurrentProperty_AfterSetBoundType()
        {
            var model = CreateViewModel();

            model.SetBoundType<TestClass>();

            Assert.IsNotNull(model.CurrentProperty);
        }

        [Test]
        public void SelectPropertyFromAvailableProperties_ShouldSetCurrentProperty()
        {
            var model = CreateViewModel();
            model.SetBoundType<TestClass>();

            var selectedProperty = model.AvailableProperties.Single(p => p.Name == "Property2");
            model.AvailableProperties.SetCurrentView(selectedProperty);

            Assert.AreEqual(selectedProperty, model.CurrentProperty);
        }

        [Test]
        public void SelectConditionFromAvailableConditions_ShouldSetCurrentCondition()
        {
            var model = CreateViewModel();
            model.SetBoundType<TestClass>();
            model.AvailableConditions = new [] { "==", "!=" };

            model.AvailableConditions.SetCurrentView("!=");

            Assert.AreEqual("!=", model.CurrentCondition);
        }

        [Test]
        public void HasSearchCommand()
        {
            var model = CreateViewModel();
            ICommand command = model.SearchCommand;
            Assert.IsNotNull(command);
        }

        [Test]
        public void RunSearchCommand_ShouldPublishSearchMessage()
        {
            var mock = new Mock<IEventAggregator>();
            var model = CreateViewModel(new Mock<IIocContainer>(), mock);

            model.SearchCommand.Execute(null);

            mock.Verify(e => e.Publish(It.IsAny<SearchCustomersMessage>()));
        }

        [Test]
        public void RunSearchCommand_ShouldPublishSearchMessage_WithCorrectSearchCriteria()
        {
            var mock = new Mock<IEventAggregator>();
            var model = CreateViewModel(new Mock<IIocContainer>(), mock);
            model.SetBoundType<TestClass>();

            var searchProperty = model.AvailableProperties.Single(p => p.Name == "Property2");
            model.CurrentProperty = searchProperty;
            model.CurrentCondition = "=";
            model.CurrentFilterText = "a";

            model.SearchCommand.Execute(null);

            mock.Verify(e => e.Publish(It.Is<SearchCustomersMessage>
                (
                    m => m.Property == searchProperty && 
                         m.Condition == "=" &&
                         m.Value == "a"
                )));
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