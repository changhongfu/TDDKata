using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TddKata
{
    public class StringCalculator
    {
        public decimal Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var delimiters = GetDelimiters(numbers);
            var numberArray = GetNumbers(delimiters, numbers);

            var negatives = numberArray.Where(num => num < 0).ToArray();
            if (negatives.Length > 0)
            {
                throw new ArgumentException("negatives not allowed: " + negatives.ToCommaDelimitedString());
            }
            return numberArray.Sum();
        }

        private static string[] GetDelimiters(string numbers)
        {
            if (numbers.StartsWith("//") == false)
            {
                return new[] { Environment.NewLine, "," };
            }

            int indexOfFirstNewLine = numbers.IndexOf(Environment.NewLine);
            string delimiters = numbers.Substring(2, indexOfFirstNewLine - 2);

            var pattern = @"\[([^\]]*)\]";
            var matches = Regex.Split(delimiters, pattern);

            return matches.Where(m => m != String.Empty).ToArray();
        }

        private static decimal[] GetNumbers(string[] delimiters, string numbers)
        {
            if (numbers.StartsWith("//"))
            {
                numbers = numbers.Substring(numbers.IndexOf(Environment.NewLine) + Environment.NewLine.Length);
            }
            var numArray = numbers.Split(delimiters, Int32.MaxValue, StringSplitOptions.RemoveEmptyEntries);
            return numArray.Select(num => Decimal.Parse(num)).ToArray();
        }
    }
}