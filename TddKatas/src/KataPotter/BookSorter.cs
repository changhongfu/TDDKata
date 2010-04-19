using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class BookSorter
    {
        public IEnumerable<BookSet> Sort(int[] books)
        {
            var booksInOrder = SortBooksInOrder(books);
            var sets = new List<BookSet>();
            foreach (var book in booksInOrder)
            {
                if (sets.All(s => !s.CanAdd(book)))
                {
                    var set = new BookSet();
                    set.Add(book);
                    sets.Add(set);
                }
                else
                {
                    sets.Where(s => s.CanAdd(book))
                        .Select(s => new {Set = s, Cost = s.CostWith(book)})
                        .OrderBy(s => s.Cost)
                        .Select(s => s.Set)
                        .First()
                        .Add(book);
                }
            }
            return sets;
        }

        private static IEnumerable<int> SortBooksInOrder(int[] books)
        {
            var result = new List<int>();
            var distinctBooks = books.Distinct();
            distinctBooks = distinctBooks.OrderByDescending(db => books.Count(b => b == db));

            foreach (var book in distinctBooks)
            {
                for (int i = 0; i < books.Count(b => b == book); i++)
                {
                    result.Add(book);
                }
            }
            return result.AsEnumerable();
        }
    }
}