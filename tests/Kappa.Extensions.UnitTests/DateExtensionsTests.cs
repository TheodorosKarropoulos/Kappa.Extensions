using Kappa.Extensions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kappa.Extensions.UnitTests
{
    public class DateExtensionsTests
    {
        [Fact]
        public void Date1_should_be_greater_than_2()
        {
            var date1 = new DateTime(2022, 12, 1);
            var date2 = new DateTime(2022, 11, 1);

            Assert.True(date1.IsGreaterThan(date2));
        }

        [Fact]
        public void Date1_should_be_less_than_2()
        {
            var date1 = new DateTime(2020, 12, 1);
            var date2 = new DateTime(2022, 11, 1);

            Assert.True(date1.IsLessThan(date2));
        }

        [Fact]
        public void DateRanges_are_intersecting()
        {
            var range1 = new DateRange(new DateTime(2022, 1, 1), new DateTime(2022, 3, 1));
            var range2 = new DateRange(new DateTime(2022, 2, 1), new DateTime(2022, 5, 1));

            Assert.True(range1.Intersects(range2));
        }

        [Fact]
        public void DateRanges_not_intersecting()
        {
            var range1 = new DateRange(new DateTime(2022, 1, 1), new DateTime(2022, 3, 1));
            var range2 = new DateRange(new DateTime(2022, 3, 2), new DateTime(2022, 5, 1));

            Assert.False(range1.Intersects(range2));
        }
    }
}
