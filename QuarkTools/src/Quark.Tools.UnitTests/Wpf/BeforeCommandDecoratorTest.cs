using System.Collections.Generic;
using System.Windows.Input;
using NUnit.Framework;
using Quark.Tools.UnitTests.Wpf.Helpers;
using Quark.Tools.Wpf.Command.Decorator;

namespace Quark.Tools.UnitTests.Wpf
{
    [TestFixture]
    public class BeforeCommandDecoratorTest
    {
        [Test]
        public void TestExecute_ShouldExecuteActualCommandCorrectly()
        {
            bool executed = false;

            ICommand command = new DelegateCommand(() => executed = true);
            command = new BeforeCommandDecorator(command, delegate { });
            command.Execute(null);

            Assert.IsTrue(executed);
        }

        [Test]
        public void TestExecute_ShouldExecuteAfterCommandAction()
        {
            bool executed = false;

            ICommand command = new DelegateCommand(delegate { });
            command = new BeforeCommandDecorator(command, () => executed = true);
            command.Execute(null);

            Assert.IsTrue(executed);
        }

        [Test]
        public void TestExecute_ShouldExecuteActionBeforeActualCommandExecution()
        {
            var record = new List<string>();

            ICommand command = new DelegateCommand(() => record.Add("a"));
            command = new BeforeCommandDecorator(command, () => record.Add("b"));
            command.Execute(null);

            Assert.AreEqual("b", record[0]);
            Assert.AreEqual("a", record[1]);
        }
    }
}