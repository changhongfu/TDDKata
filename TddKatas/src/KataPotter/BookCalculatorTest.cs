using NUnit.Framework;

namespace KataPotter
{
    [TestFixture]
    public class BookCalculatorTest
    {
        [Test]
        public void CalculatePrice_EmptyBasket()
        {
            var calculator = new BookCalculator();
            var price = calculator.CalculatePrice(new int[0]);
            Assert.AreEqual(0, price);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void CalculatePrice_1Book(int bookNumber)
        {
            var calculator = new BookCalculator();
            var price = calculator.CalculatePrice(new [] { bookNumber });
            Assert.AreEqual(8, price);
        }

        [Test]
        public void CalculatePrice_2Books_5PercentDiscount()
        {
            var calculator = new BookCalculator();
            var price = calculator.CalculatePrice(new[] { 1, 2 });
            Assert.AreEqual(15.2m, price);
        }

        [Test]
        public void CalculatePrice_3Books_10PercentDiscount()
        {
            var calculator = new BookCalculator();
            var price = calculator.CalculatePrice(new[] { 1, 2, 3 });
            Assert.AreEqual(21.6m, price);
        }

        [Test]
        public void CalculatePrice_4Books_20PercentDiscount()
        {
            var calculator = new BookCalculator();
            var price = calculator.CalculatePrice(new[] { 1, 2, 3, 4 });
            Assert.AreEqual(25.6m, price);
        }

        [Test]
        public void CalculatePrice_5Books_25PercentDiscount()
        {
            var calculator = new BookCalculator();
            var price = calculator.CalculatePrice(new[] { 1, 2, 3, 4, 5 });
            Assert.AreEqual(30m, price);
        }

        [Test]
        public void CalculatePrice_SameBook_NoDiscount()
        {
            var calculator = new BookCalculator();
            var price = calculator.CalculatePrice(new[] { 1, 1 });
            Assert.AreEqual(16m, price);
        }

        [Test]
        public void CalculatePrice_2SetOfBooks()
        {
            var calculator = new BookCalculator();
            var price = calculator.CalculatePrice(new[] { 1, 1, 2, 3, 4, 5, 5 });
            Assert.AreEqual(45.2m, price);
        }

        [Test]
        public void CalculatePrice_2Sets_BestPrice()
        {
            var calculator = new BookCalculator();
            var price = calculator.CalculatePrice(new[] { 1, 1, 2, 2, 3, 3, 4, 5 });
            Assert.AreEqual(51.2m, price);
        }
    }
}