using System.Collections.Generic;
using System.Linq;

namespace Kappa.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool NullOrEmpty<T>(this IEnumerable<T> enumerable)
            => enumerable is null || !enumerable.Any();

        public static bool HasMoreThanOne<T>(this IEnumerable<T> enumerable)
            => enumerable.Count() > 1;
    }
}