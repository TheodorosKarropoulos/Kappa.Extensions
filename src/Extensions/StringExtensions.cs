using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

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

        public static bool TryDeserialize<T>(this string str, out T result)
        {
            if(str.IsNullOrEmpty() || str.IsNullOrWhiteSpace())
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
