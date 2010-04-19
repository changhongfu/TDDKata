using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    internal class BookSet
    {
        private readonly List<int> books = new List<int>();

        public BookSet()
        {
        }

        public BookSet(int book)
        {
            books.Add(book);
        }

        public decimal Total
        {
            get { return TotalWith(books); }
        }

        private static decimal ComputeDiscount(IEnumerable<int> books)
        {
            switch (books.Count())
            {
                case 1: return 0;
                case 2: return 0.05m;
                case 3: return 0.1m;
                case 4: return 0.2m;
                case 5: return 0.25m;
                default: throw new NotSupportedException();
            }
        }

        public bool CanAccept(int book)
        {
            return !books.Contains(book);
        }

        public void Accept(int book)
        {
            books.Add(book);
        }

        public decimal TotalWith(int book)
        {
            return TotalWith(books.Concat(new[] { book }));
        }

        private static decimal TotalWith(IEnumerable<int> books)
        {
            return 8 * books.Count() * (1 - ComputeDiscount(books));
        }

        public BookSet Clone()
        {
            var clone = new BookSet();
            foreach (var book in books)
            {
                clone.books.Add(book);
            }
            return clone;
        }
    }
}