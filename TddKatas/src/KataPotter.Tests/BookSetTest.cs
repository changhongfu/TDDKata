using System;
using NUnit.Framework;

namespace KataPotter.Tests
{
    [TestFixture]
    public class BookSetTest
    {
        [Test]
        public void CanAdd_BookNotInSet_ReturnTrue()
        {
            var set = new BookSet();
            Assert.IsTrue(set.CanAdd(1));
        }

        [Test]
        public void CanAdd_DuplicateBook_ReturnFalse()
        {
            var set = new BookSet();
            set.Add(1);
            Assert.IsFalse(set.CanAdd(1));
        }

        [Test]
        public void Add_DuplicateBook_Throws()
        {
            var set = new BookSet();
            set.Add(1);
            Assert.Throws<InvalidOperationException>(() => set.Add(1));
        }

        [Test]
        public void Cost_Empty()
        {
            var set = new BookSet();
            Assert.AreEqual(0, set.Cost());            
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void Cost_1Book(int book)
        {
            var set = new BookSet();
            set.Add(book);
            Assert.AreEqual(8, set.Cost());    
        }

        [TestCase(1, 2)]
        [TestCase(1, 5)]
        [TestCase(4, 5)]
        public void Cost_2Books(int book1, int book2)
        {
            var set = new BookSet();
            set.Add(book1);
            set.Add(book2);
            Assert.AreEqual(8 * 2 * 0.95, set.Cost());
        }

        [TestCase(1, 2, 3)]
        [TestCase(3, 4, 5)]
        public void Cost_3Books(int book1, int book2, int book3)
        {
            var set = new BookSet();
            set.Add(book1);
            set.Add(book2);
            set.Add(book3);
            Assert.AreEqual(8 * 3 * 0.90, set.Cost());
        }

        [TestCase(1, 2, 3, 4)]
        [TestCase(2, 3, 4, 5)]
        public void Cost_4Books(int book1, int book2, int book3, int book4)
        {
            var set = new BookSet();
            set.Add(book1);
            set.Add(book2);
            set.Add(book3);
            set.Add(book4);
            Assert.AreEqual(8 * 4 * 0.80, set.Cost());
        }

        [Test]
        public void Cost_4Books()
        {
            var set = new BookSet();
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            Assert.AreEqual(8 * 5 * 0.75, set.Cost());
        }
    }
}