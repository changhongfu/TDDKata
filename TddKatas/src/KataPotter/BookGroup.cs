using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class BookGroup
    {
        private readonly List<BookSet> _bookSets = new List<BookSet>();

        public void AddNewSetFor(int book)
        {
            _bookSets.Add(new BookSet(book));
        }

        public IEnumerable<BookGroup> CreateNewGroupToAdd(int book)
        {
            return _bookSets.Where(set => set.CanAccept(book))
                            .Select(bookSet => CreateNewGroup(bookSet, book))
                            .ToList();
        }

        private BookGroup CreateNewGroup(BookSet bookSet, int book)
        {
            var bookGroup = new BookGroup();
            foreach (var set in _bookSets)
            {
                var newBookSet = set.Clone();
                if (set == bookSet)
                {
                    newBookSet.Accept(book);
                }
                bookGroup.Add(newBookSet);
            }

            return bookGroup;
        }

        private void Add(BookSet bookSet)
        {
            _bookSets.Add(bookSet);
        }

        public decimal Cost()
        {
            return _bookSets.Sum(set => set.Total);
        }
    }
}