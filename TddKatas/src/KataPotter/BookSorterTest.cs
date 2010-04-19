using System.Linq;
using NUnit.Framework;

namespace KataPotter
{
    [TestFixture]
    public class BookSorterTest
    {
        [Test]
        public void SortBook_NoBooks()
        {
            var sorter = new BookSorter();

            var bookSets = sorter.Sort(new int[0]);

            Assert.AreEqual(0, bookSets.Count());
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void SortBook_1Book(int bookNumber)
        {
            var sorter = new BookSorter();

            var bookSets = sorter.Sort(new[] { bookNumber }).ToArray();

            Assert.AreEqual(1, bookSets.Length);
            Assert.AreEqual(1, bookSets[0].Length);
            Assert.AreEqual(bookNumber, bookSets[0][0]);
        }

        [TestCase(1, 2)]
        [TestCase(1, 3)]
        [TestCase(4, 5)]
        public void SortBook_2DifferentBooks(int book1, int book2)
        {
            var sorter = new BookSorter();

            var bookSets = sorter.Sort(new[] { book1, book2 }).ToArray();

            Assert.AreEqual(1, bookSets.Length);
            Assert.AreEqual(2, bookSets[0].Length);
            Assert.AreEqual(book1, bookSets[0][0]);
            Assert.AreEqual(book2, bookSets[0][1]);
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        public void SortBook_2SameBooks(int book1, int book2)
        {
            var sorter = new BookSorter();

            var bookSets = sorter.Sort(new[] { book1, book2 }).ToArray();

            Assert.AreEqual(2, bookSets.Length);
            Assert.AreEqual(1, bookSets[0].Length);
            Assert.AreEqual(book1, bookSets[0][0]);
            Assert.AreEqual(book2, bookSets[1][0]);
        }

        [Test]
        public void SortBook_5DifferentBooks()
        {
            var sorter = new BookSorter();

            var bookSets = sorter.Sort(new[] { 1, 2, 3, 4, 5 }).ToArray();

            Assert.AreEqual(1, bookSets.Length);
            AssertBookSet(new[] { 1, 2, 3, 4, 5 }, bookSets[0]);
        }

        [Test]
        public void SortBook_2SetOfBooks()
        {
            var sorter = new BookSorter();

            var bookSets = sorter.Sort(new[] { 1, 1, 2, 3, 4, 5, 5 }).ToArray();

            Assert.AreEqual(2, bookSets.Length);
            AssertBookSet(new[] { 1, 2, 3, 4, 5 }, bookSets[0]);
            AssertBookSet(new[] {1, 5}, bookSets[1]);
        }

        [Test]
        public void SortBook_2SetOf4Over1Setof5And1SetOf3()
        {
            var sorter = new BookSorter();

            var bookSets = sorter.Sort(new[] { 1, 2, 3, 4, 5, 1, 2, 3 }).ToArray();

            AssertBookSet(new[] { 1, 2, 3, 5 }, bookSets[0]);
            AssertBookSet(new[] { 1, 2, 3, 4 }, bookSets[1]);
        }


        [Test]
        public void SortBook_5Sets()
        {
            var sorter = new BookSorter();

            var bookSets = sorter.Sort(new[]
            {
                1, 1, 1, 1, 1,
                2, 2, 2, 2, 2,
                3, 3, 3, 3, 
                4, 4, 4, 4,
                5, 5, 5, 5, 5
            }).ToArray();

            AssertBookSet(new[] { 1, 2, 4, 5 }, bookSets[0]);
            AssertBookSet(new[] { 1, 2, 3, 4, 5 }, bookSets[1]);
            AssertBookSet(new[] { 1, 2, 3, 4, 5 }, bookSets[2]);
            AssertBookSet(new[] { 1, 2, 3, 4, 5 }, bookSets[3]);
            AssertBookSet(new[] { 1, 2, 5, 3 }, bookSets[4]);
        }

        private static void AssertBookSet(int[] expected, int[] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}