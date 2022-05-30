using System;

namespace Kappa.Extensions.ValueObjects
{
    public struct DateRange
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public DateRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public static bool operator ==(DateRange range1, DateRange range2)
        {
            return range1.Start.Equals(range2.Start) && range1.End.Equals(range2.End);
        }

        public static bool operator !=(DateRange range1, DateRange range2)
        {
            return !range1.Start.Equals(range2.Start) || !range1.End.Equals(range2.End);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj is DateRange);
        }

        public override string ToString()
        {
            return $"{Start} - {End}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Start.GetHashCode(), End.GetHashCode());
        }
    }
}
