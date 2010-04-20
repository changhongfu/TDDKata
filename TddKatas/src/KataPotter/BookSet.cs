using System;
using System.Collections.Generic;

namespace KataPotter
{
    public class BookSet
    {
        private static readonly decimal[] DiscountTable = new[] { 0, 1, 0.95m, 0.9m, 0.8m, 0.75m };

        private readonly IList<int> _books = new List<int>();

        public BookSet()
        {
        }

        public BookSet(int book)
        {
            _books.Add(book);
        }

        public bool CanAdd(int book)
        {
            return !_books.Contains(book);
        }

        public void Add(int book)
        {
            if (!CanAdd(book))
            {
               throw new InvalidOperationException("Book " + book + " already in this set");
            }
            _books.Add(book);
        }

        public decimal Cost()
        {
            return _books.Count * 8 * GetDiscount();
        }

        private decimal GetDiscount()
        {
            return DiscountTable[_books.Count];
        }

        public decimal CostWith(int book)
        {
            var set = new BookSet();
            foreach (var b in _books)
            {
                set.Add(b);
            }
            set.Add(book);
            return set.Cost();
        }
    }
}