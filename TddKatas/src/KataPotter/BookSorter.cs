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
            booksInOrder.ForEach(b =>
            {
                if (sets.Any(s => s.CanAdd(b)))
                {
                    AddBookToSet(sets, b);
                }
                else
                {
                    sets.Add(new BookSet(b));
                }
            });
            
            return sets;
        }

        private static IEnumerable<int> SortBooksInOrder(IEnumerable<int> books)
        {
            var result = new List<int>();
            books.Distinct()
                 .Select(b => new { Book = b, Count = books.Count(book => book == b) })
                 .OrderByDescending(b => b.Count)
                 .ForEach(b => b.Count.Times(() => result.Add(b.Book)));

            return result.AsEnumerable();
        }

        private static void AddBookToSet(IEnumerable<BookSet> sets, int book)
        {
            sets.Where(s => s.CanAdd(book))
                .Select(s => new {Set = s, Cost = s.CostWith(book)})
                .OrderBy(s => s.Cost)
                .Select(s => s.Set)
                .First()
                .Add(book);
        }
    }
}