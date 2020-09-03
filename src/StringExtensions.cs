using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kappa.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string source) => string.IsNullOrEmpty(source);
        public static bool IsNullOrWhiteSpace(this string source) => string.IsNullOrWhiteSpace(source);

        public static string GetNumbers(this string source)
            => new string(source.Where(c => char.IsDigit(c)).ToArray());

        public static bool IsAlphanumeric(this string source)
            => source.All(char.IsLetterOrDigit);

        public static string StripAllWhiteSpace(this string source)
         => Regex.Replace(source.IsNullOrEmpty() ? string.Empty : source, @"\s+", "");

        public static bool ContainsAny(this string source, IEnumerable<string> strings)
            => strings?.Any(x => source.Contains(x)) ?? false;

        public static bool NotContainNumbers(this string source) 
            => !(source.Any(char.IsDigit));
    }
}
