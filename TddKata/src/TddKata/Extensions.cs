using System.Collections.Generic;
using System.Text;

namespace TddKata
{
    public static class Extensions
    {
        public static string ToCommaDelimitedString<T>(this IEnumerable<T> values)
        {
            var sb = new StringBuilder();
            foreach (var value in values)
            {
                sb.Append(value.ToString());
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }
    }
}