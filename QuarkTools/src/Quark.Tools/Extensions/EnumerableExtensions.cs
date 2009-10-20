using System.Collections.Generic;
using System.Linq;

namespace Quark.Tools.Extensions
{
    public static class EnumerableExtensions
    {
        public static TReal FindOrCreate<TReal, TBase>(this ICollection<TBase> collection) where TReal : class, TBase, new()
        {
            var existing = collection.SingleOrDefault(item => item.GetType() == typeof(TReal)) as TReal;
            if (existing != null)
            {
                return existing;
            }
            var newInstance = new TReal();
            collection.Add(newInstance);

            return newInstance;
        }
    }
}