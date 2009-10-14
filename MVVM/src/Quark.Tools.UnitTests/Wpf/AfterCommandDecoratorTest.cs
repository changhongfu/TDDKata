using System.Collections.Generic;
using System.Windows.Input;
using NUnit.Framework;
using Quark.Tools.UnitTests.Wpf.Helpers;
using Quark.Tools.Wpf.Command.Decorator;

namespace Quark.Tools.UnitTests.Wpf
{
    [TestFixture]
    public class AfterCommandDecoratorTest
    {
        [Test]
        public void TestExecute_ShouldExecuteActualCommandCorrectly()
        {
            bool executed = false;

            ICommand command = new DelegateCommand(() => executed = true);
            command = new AfterCommandDecorator(command, delegate { });
            command.Execute(null);

            Assert.IsTrue(executed);
        }

        [Test]
        public void TestExecute_ShouldExecuteAfterCommandAction()
        {
            bool executed = false;

            ICommand command = new DelegateCommand(delegate { });
            command = new AfterCommandDecorator(command, () => executed = true);
            command.Execute(null);

            Assert.IsTrue(executed);
        }

        [Test]
        public void TestExecute_ShouldExecuteActionAfterActualCommandExecution()
        {
            var record = new List<string>();

            ICommand command = new DelegateCommand(() => record.Add("a"));
            command = new AfterCommandDecorator(command, () => record.Add("b"));
            command.Execute(null);

            Assert.AreEqual("a", record[0]);
            Assert.AreEqual("b", record[1]);
        }
    }
}