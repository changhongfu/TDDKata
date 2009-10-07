using NUnit.Framework;
using Quark.Tools.Mvvm;

namespace Quark.Tools.UnitTests.Mvvm
{
    [TestFixture]
    public class RelayCommandTest
    {
        [Test]
        public void TestConstructor_TakeActionParameter()
        {
            var command = new RelayCommand(delegate { });
            Assert.IsNotNull(command);
        }

        [Test]
        public void TestConstructor_CanAssignFunctionForCanExecute()
        {
            var command = new RelayCommand(delegate { }, p => true);
            Assert.IsNotNull(command);
        }

        [Test]
        public void TestExecute_ShouldExecuteAction()
        {
            bool execute = false;
            var command = new RelayCommand(delegate { execute = true; });

            command.Execute(null);

            Assert.IsTrue(execute);
        }

        [Test]
        public void TestCanExecute_ShouldReturnTrue_IfCanExecuteFuncIsNull()
        {
            var command = new RelayCommand(delegate { });

            bool canExecute = command.CanExecute(null);

            Assert.IsTrue(canExecute);
        }

        [Test]
        public void TestCanExecute_ShouldReturnTrue_IfCanExecuteFuncReturnTrue()
        {
            var command = new RelayCommand(delegate { }, p => true);

            bool canExecute = command.CanExecute(null);

            Assert.IsTrue(canExecute);
        }

        [Test]
        public void TestCanExecute_ShouldReturnFalse_IfCanExecuteFuncReturnFalse()
        {
            var command = new RelayCommand(delegate { }, p => false);

            bool canExecute = command.CanExecute(null);

            Assert.IsFalse(canExecute);
        }
    }
}