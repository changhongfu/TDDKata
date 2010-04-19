using System.Linq;
using NUnit.Framework;

namespace KataPotter.Tests
{
    [TestFixture]
    public class BookSorterTest
    {
        [Test]
        public void Sort_Empty()
        {
            var sorter = new BookSorter();
            var sets = sorter.Sort(new int[0]);
            Assert.AreEqual(0, sets.Count());
        }

        [Test]
        public void Sort_1Book()
        {
            var sorter = new BookSorter();
            var sets = sorter.Sort(new [] { 1 });
            Assert.AreEqual(1, sets.Count());
        }

        [Test]
        public void Sort_2SameBooks()
        {
            var sorter = new BookSorter();
            var sets = sorter.Sort(new[] { 1, 1 });
            Assert.AreEqual(2, sets.Count());
        }

        [Test]
        public void Sort_8Books()
        {
            var sorter = new BookSorter();
            var sets = sorter.Sort(new[] { 1, 2, 3, 4, 5, 1, 2, 3 });
            Assert.AreEqual(2, sets.Count());
        }

        [Test]
        public void Sort_2Books()
        {
            var sorter = new BookSorter();
            var sets = sorter.Sort(new[] { 0, 1, 2, 2, 3, 3, 4, 4 });
            Assert.AreEqual(2, sets.Count());
        }
    }
}