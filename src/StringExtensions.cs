using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Kappa.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if a string is null or empty
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string source) => string.IsNullOrEmpty(source);

        /// <summary>
        /// Checks if a string is null or white space
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string source) => string.IsNullOrWhiteSpace(source);

        /// <summary>
        /// Checks if a string is null, empty, or white space
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmptyOrWhiteSpace(this string source)
            => source.IsNullOrWhiteSpace() || source.IsNullOrEmpty();

        /// <summary>
        /// Returns all digits from a string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetNumbers(this string source)
            => new string(source.Where(c => char.IsDigit(c)).ToArray());

        /// <summary>
        /// Checks if a string consists only from alphanumeric characters
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsAlphanumeric(this string source)
            => source.All(char.IsLetterOrDigit);

        /// <summary>
        /// Remove all white spaces from a string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string StripAllWhiteSpace(this string source)
         => Regex.Replace(source.IsNullOrEmpty() ? string.Empty : source, @"\s+", "");

        /// <summary>
        /// Check if a string contains a given string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static bool ContainsAny(this string source, IEnumerable<string> strings)
            => strings?.Any(x => source.Contains(x)) ?? false;

        /// <summary>
        /// Check if a string contains no digits
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool NotContainNumbers(this string source)
            => !(source.Any(char.IsDigit));

        /// <summary>
        /// Try to deserialize a string into a given object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryDeserialize<T>(this string str, out T result)
        {
            if (str.IsNullOrEmpty() || str.IsNullOrWhiteSpace())
            {
                result = default(T);
                return false;
            }

            var success = true;
            var settings = new JsonSerializerSettings
            {
                Error = (sender, args) => { success = false; args.ErrorContext.Handled = true; },
                MissingMemberHandling = MissingMemberHandling.Error
            };

            try
            {
                result = JsonConvert.DeserializeObject<T>(str, settings);
                return success;
            }
            catch (System.Exception)
            {
                result = default(T);
                return false;
            }

        }

        /// <summary>
        /// Mask a given string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="numberOfCharsToSkip"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public static string Mask(this string source, int numberOfCharsToSkip, char mask)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source)) return default;

            source = source.Trim();

            if (numberOfCharsToSkip > source.Length || numberOfCharsToSkip < 0) return source;

            return string.Create(source.Length, source, (span, value) =>
            {
                value.AsSpan().CopyTo(span);
                span[numberOfCharsToSkip..].Fill(mask);
            });
        }
    }
}
