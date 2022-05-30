using Kappa.Extensions.ValueObjects;
using System;

namespace Kappa.Extensions
{
    public static class DateExtensions
    {
        public static bool IsGreaterThan(this DateTime date, DateTime date2)
        {
            return date.CompareTo(date2) > 0;
        }

        public static bool IsLessThan(this DateTime date, DateTime date2)
        {
            return date.CompareTo(date2) < 0;
        }

        public static bool Intersects(this DateRange range1, DateRange range2)
        {
            return range1.Start <= range2.End && range2.Start <= range1.End;
        }
    }
}
