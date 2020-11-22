using System;
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

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return _(); IEnumerable<TSource> _()
            {
                var knownKeys = new HashSet<TKey>(comparer);
                foreach (var element in source)
                {
                    if (knownKeys.Add(keySelector(element)))
                        yield return element;
                }
            }
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source,
              Func<TSource, TKey> keySelector)
        {
            return source.DistinctBy(keySelector, null);
        }

        public static IDictionary<TKey, TValue> ToSafeDictionaryOrDefault<TElement, TKey, TValue>(this IEnumerable<TElement> source, Func<TElement, TKey> key, Func<TElement, TValue> value)
            => source?.DistinctBy(key)?.ToDictionary(key, value) ?? new Dictionary<TKey, TValue>();
    }
}