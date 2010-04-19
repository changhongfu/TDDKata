using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class BookCalculator
    {
        public decimal CalculatePrice(int[] books)
        {
            return GetBookSets(books).Sum(bookSet => CalculateBookSet(bookSet));
        }

        private static IEnumerable<int[]> GetBookSets(int[] books)
        {
            var sorter = new BookSorter();
            return sorter.Sort(books);
        }

        private static decimal CalculateBookSet(int[] bookSet)
        {
            decimal discount = GetDiscount(bookSet.Length);
            return (1 - discount) * 8 * bookSet.Length;
        }

        private static decimal GetDiscount(int numBooks)
        {
            return numBooks == 2 ? 0.05m :
                   numBooks == 3 ? 0.1m :
                   numBooks == 4 ? 0.2m :
                   numBooks == 5 ? 0.25m :
                   0m;
        }
    }
}