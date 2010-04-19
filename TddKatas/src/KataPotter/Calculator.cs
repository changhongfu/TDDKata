using System.Linq;

namespace KataPotter
{
    public class Calculator
    {
        public decimal Price(params int[] books)
        {
            return new BookSorter().Sort(books).Sum(set => set.Cost());
        }
    }
}