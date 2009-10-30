using System;
using NUnit.Framework;

namespace TddKata.Tests
{
    [TestFixture]
    public class StringCalculatorTest
    {
        [Test]
        public void Add_ShouldReturnZero_IfParameterStringIsEmpty()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("");
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_ShouldReturnNumber_IfOnlyOneNumberInParameterString()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("1");
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Add_ShouldAddNumbers_IfTwoNumbersInParameterString()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("1,2");
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_ShouldAddNumbers_IfThreeNumbersInParameterString()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("1,2,3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_ShouldBeAbleToHandleNewLineInParameterString()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(@"1
2");
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_ShouldBeAbleToHandleBothNewLineAndCommaParameterString()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(@"1,
2,3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_ShouldBeAbleToHandleUserDefinedDelimiter()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(@"//;
1;2");
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_UserDefinedDelimiterCanBeMoreThanOneCharacterLong()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(@"//***
1***2***3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_UserDefinedDelimiterCanBeMoreThanOneDelimiters()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(@"//[*][%]
1*2%3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_ThrowsException_IfNegativeNumberInParameterString()
        {
            var calculator = new StringCalculator();
            Assert.Throws(typeof (ArgumentException), () => calculator.Add("-1"));
        }

        [Test]
        public void Add_MessageOfExceptionThrownShowsTheNegativeNumbers_IfNegativeNumberInParameterString()
        {
            var calculator = new StringCalculator();
            var ex = Assert.Throws<ArgumentException>(() => calculator.Add("-1,-2"));
            Assert.AreEqual("negatives not allowed: -1, -2", ex.Message);
        }

        [Test]
        public void Add_ShouldBeAbleToHandleDoubleValues()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("1.1,2.2");
            Assert.AreEqual(3.3, result);
        }
    }
}