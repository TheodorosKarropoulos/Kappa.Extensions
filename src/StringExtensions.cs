using System;
using System.Globalization;
using System.Linq;

namespace Kappa.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);
        public static bool IsNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);

        public static string GetNumbers(this string source)
            => new string(source.Where(c => char.IsDigit(c)).ToArray());
    }
}
