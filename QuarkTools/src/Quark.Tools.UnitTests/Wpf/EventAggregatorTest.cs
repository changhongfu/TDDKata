using System;
using NUnit.Framework;
using Quark.Tools.Wpf.Events;

namespace Quark.Tools.UnitTests.Wpf
{
    [TestFixture]
    public class EventAggregatorTest
    {
        [Test]
        public void CanAddListenerToEventAggregator()
        {
            var eventAggregator = new EventAggregator();
            bool added = false;

            eventAggregator.AddListener<Message<string>>(m => added = true);
            eventAggregator.SendMessage(new Message<string>("a"));

            Assert.IsTrue(added);
        }

        [Test]
        public void ShouldSendCorrectEventMessageDataItem()
        {
            var eventAggregator = new EventAggregator();
            string messageData = String.Empty;

            eventAggregator.AddListener<Message<string>>(m => messageData = m.DataItem);
            eventAggregator.SendMessage(new Message<string>("a"));

            Assert.AreEqual("a", messageData);
        }

        [Test]
        public void ShouldOnlyInvokeHandlerForCorrectMessageType()
        {
            var eventAggregator = new EventAggregator();

            bool invoked = false;

            eventAggregator.AddListener<Message<bool>>(m => invoked = true);
            eventAggregator.SendMessage(new Message<string>("a"));  //Message type is Message<string>, should not invoke hanlder for Message<bool>

            Assert.IsFalse(invoked);
        }
    }
}