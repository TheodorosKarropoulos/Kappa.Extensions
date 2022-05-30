using System;
using System.Collections.Generic;
using System.Linq;

namespace Kappa.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
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

        public static bool TryGetFirstOrDefault<TSource>(this IEnumerable<TSource> source, out TSource result)
        {
            if (source.IsNullOrEmpty())
            {
                result = default;
                return false;
            }

            result = source.FirstOrDefault();
            return result != null;
        }

        public static bool TryGetFirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, out TSource result)
        {
            if (source.IsNullOrEmpty())
            {
                result = default;
                return false;
            }

            result = source.FirstOrDefault(predicate);
            return result != null;
        }

        public static bool TryGetFirst<TSource>(this IEnumerable<TSource> source, out TSource result)
        {
            if (source.IsNullOrEmpty())
            {
                result = default;
                return false;
            }

            result = source.First();
            return result != null;
        }

        public static bool TryGetFirst<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, out TSource result)
        {
            if (source.IsNullOrEmpty())
            {
                result = default;
                return false;
            }

            result = source.First(predicate);
            return result != null;
        }

        public static decimal Product<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (selector == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            decimal product = 1;

            foreach (var item in source)
            {
                var multiplier = selector(item);
                if (multiplier == 0)
                {
                    return multiplier;
                }

                product *= multiplier;
            }

            return product;
        }

        public static double Product<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (selector == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            double product = 1;

            foreach (var item in source)
            {
                var multiplier = selector(item);
                if (multiplier == 0)
                {
                    return multiplier;
                }

                product *= multiplier;
            }

            return product;
        }

        public static int Product<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (selector == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            int product = 1;

            foreach (var item in source)
            {
                var multiplier = selector(item);
                if (multiplier == 0)
                {
                    return multiplier;
                }

                product *= multiplier;
            }

            return product;
        }

        public static float Product<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (selector == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            float product = 1;

            foreach (var item in source)
            {
                var multiplier = selector(item);
                if (multiplier == 0)
                {
                    return multiplier;
                }

                product *= multiplier;
            }

            return product;
        }

        public static long Product<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (selector == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            long product = 1;

            foreach (var item in source)
            {
                var multiplier = selector(item);
                if (multiplier == 0)
                {
                    return multiplier;
                }

                product *= multiplier;
            }

            return product;
        }

        public static decimal? Product<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (selector == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            decimal product = 1;

            foreach (var item in source)
            {
                decimal? multiplier = selector(item);
                if (!multiplier.HasValue || multiplier == 0)
                {
                    return 0;
                }

                product *= multiplier.Value;
            }

            return product;
        }

        public static double? Product<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (selector == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            double product = 1;

            foreach (var item in source)
            {
                double? multiplier = selector(item);
                if (!multiplier.HasValue || multiplier == 0)
                {
                    return 0;
                }

                product *= multiplier.Value;
            }

            return product;
        }

        public static int? Product<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (selector == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            int product = 1;

            foreach (var item in source)
            {
                int? multiplier = selector(item);
                if (!multiplier.HasValue || multiplier == 0)
                {
                    return 0;
                }

                product *= multiplier.Value;
            }

            return product;
        }

        public static float? Product<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (selector == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            float product = 1;

            foreach (var item in source)
            {
                float? multiplier = selector(item);
                if (!multiplier.HasValue || multiplier == 0)
                {
                    return 0;
                }

                product *= multiplier.Value;
            }

            return product;
        }

        public static long? Product<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (selector == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            long product = 1;

            foreach (var item in source)
            {
                long? multiplier = selector(item);
                if (!multiplier.HasValue || multiplier == 0)
                {
                    return 0;
                }

                product *= multiplier.Value;
            }

            return product;
        }

        public static decimal Product(this IEnumerable<decimal> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            decimal product = 1;

            foreach (var item in source)
            {
                product *= item;
            }

            return product;
        }

        public static double Product(this IEnumerable<double> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            double product = 1;
            foreach (var item in source)
            {
                product *= item;
            }

            return product;
        }

        public static int Product(this IEnumerable<int> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            int product = 1;

            foreach (var item in source)
            {
                product *= item;
            }

            return product;
        }

        public static float Product(this IEnumerable<float> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            float product = 1;

            foreach (var item in source)
            {
                product *= item;
            }

            return product;
        }

        public static long Product(this IEnumerable<long> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            long product = 1;

            foreach (var item in source)
            {
                product *= item;
            }

            return product;
        }

        public static decimal? Product(this IEnumerable<decimal?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            decimal product = 1;

            foreach (var item in source)
            {
                if (!item.HasValue || item == 0)
                {
                    return 0;
                }

                product *= item.Value;
            }

            return product;
        }

        public static double? Product(this IEnumerable<double?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            double product = 1;
            
            foreach (var item in source)
            {
                if (!item.HasValue || item == 0)
                {
                    return 0;
                }

                product *= item.Value;
            }

            return product;
        }

        public static int? Product(this IEnumerable<int?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            int product = 1;

            foreach (var item in source)
            {
                if (!item.HasValue || item == 0)
                {
                    return 0;
                }

                product *= item.Value;
            }

            return product;
        }

        public static float? Product(this IEnumerable<float?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            float product = 1;

            foreach (var item in source)
            {
                if (!item.HasValue || item == 0)
                {
                    return 0;
                }

                product *= item.Value;
            }

            return product;
        }

        public static long? Product(this IEnumerable<long?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (!source.Any())
            {
                return default;
            }

            long product = 1;

            foreach (var item in source)
            {
                if (!item.HasValue || item == 0)
                {
                    return 0;
                }

                product *= item.Value;
            }

            return product;
        }
    }
}