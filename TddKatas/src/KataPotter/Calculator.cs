using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class Calculator
    {
        public decimal Price(params int[] books)
        {
            if (books.Length == 0)
            {
                return 0;
            }

            var possibleGroup = new List<BookGroup>();

            foreach (var book in books)
            {
                var newGroups = new List<BookGroup>();

                if (possibleGroup.Count == 0)
                {
                    var bookGroup = new BookGroup();
                    bookGroup.AddNewSetFor(book);
                    newGroups.Add(bookGroup);
                }


                foreach (var group in possibleGroup)
                {
                    newGroups.AddRange(group.CreateNewGroupToAdd(book));
                    group.AddNewSetFor(book);
                }

               
                possibleGroup.AddRange(newGroups);
            }

            return possibleGroup.Min(g => g.Cost());
        }
    }
}