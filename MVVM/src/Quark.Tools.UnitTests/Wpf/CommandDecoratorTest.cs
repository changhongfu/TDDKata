using System;
using System.Windows.Input;
using NUnit.Framework;
using Quark.Tools.UnitTests.Wpf.Helpers;
using Quark.Tools.Wpf.Command.Decorator;

namespace Quark.Tools.UnitTests.Wpf
{
    [TestFixture]
    public class CommandDecoratorTest
    {
        [Test]
        public void TestCanExecute_ShouldReturnFalse_IfActualCommandCannotExecute()
        {
            ICommand command = new DelegateCommand(null);  //command cannot execute as its action is null
            command = new CommandDecoratorStub(command);

            Assert.IsFalse(command.CanExecute(null));
        }

        [Test]
        public void TestCanExecute_ShouldReturnTrue_IfActualCommandCanExecute()
        {
            ICommand command = new DelegateCommand(delegate { }); //command cannot execute as action is not null
            command = new CommandDecoratorStub(command);

            Assert.IsTrue(command.CanExecute(null));
        }

        [Test]
        public void TestCanExecuteChanged_ShouldBeAbleToSubscribeThisEventFromDecorator()
        {
            var command = new DelegateCommand(null);
            var decoratedCommand = new CommandDecoratorStub(command);

            bool raised = false;
            EventHandler handler = (sender, args) => raised = true;
            decoratedCommand.CanExecuteChanged += handler;

            command.Action = delegate { };  //This will cause CanExecuteChanged raise from actual command

            Assert.IsTrue(raised);          //Should be able to subscrib this event from the decorator         
        }

        [Test]
        public void TestCanExecuteChanged_ShouldBeAbleToUnSubscribeThisEventFromDecorator()
        {
            var command = new DelegateCommand(null);
            var decoratedCommand = new CommandDecoratorStub(command);

            bool raised = false;
            EventHandler handler = (sender, args) => raised = true;
            decoratedCommand.CanExecuteChanged += handler;
            decoratedCommand.CanExecuteChanged -= handler;

            command.Action = delegate { }; 

            Assert.IsFalse(raised);            
        }


        private class CommandDecoratorStub : CommandDecorator
        {
            public CommandDecoratorStub(ICommand command) : base(command)
            {
            }

            public override void Execute(object parameter)
            {
                throw new NotImplementedException();
            }
        }
    }
}