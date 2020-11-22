using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace Kappa.Extensions.UnitTests
{
    public class EnumerableExtensionsTests
    {
        [Fact]
        public void NullOrEmpty_Should_Return_False()
        {
            var enumerable = new List<string> { "test", "demo" };

            enumerable.NullOrEmpty().Should().BeFalse();
        }

        [Fact]
        public void NullOrEmpty_Should_Return_True()
        {
            var enumerable = new List<string>();

            enumerable.NullOrEmpty().Should().BeTrue();
        }

        [Fact]
        public void NullOrEmpty_For_Null_Enumerable_Should_Return_True()
        {
            IEnumerable<string> enumerable = null;

            enumerable.NullOrEmpty().Should().BeTrue();
        }

        [Fact]
        public void ToSafeDictionaryOrDefault_Should_Remove_Duplicate_Keys()
        {
            var dict = new List<object>
            {
                new { Key = 1, Value = "One" },
                new { Key = 1, Value = "One" },
                new { Key = 2, Value = "Two" },
                new { Key = 3, Value = "Three" },
                new { Key = 3, Value = "Three" },
                new { Key = 4, Value = "Four" },
                new { Key = 5, Value = "Five" },
                new { Key = 5, Value = "Five" }
            };

            var safeDict = dict.ToSafeDictionaryOrDefault(x => x, y => y);
            var douplicates = safeDict.GroupBy(x => x).Where(x => x.Count() > 1).ToList();

            Assert.True(douplicates.NullOrEmpty());
        }

        [Fact]
        public void ToSafeDictionaryOrDefault_Should_Return_Empty_Dictionary()
        {
            var dict = new List<object>
            {
                
            };

            var safeDict = dict.ToSafeDictionaryOrDefault(x => x, y => y);

            Assert.True(safeDict.NullOrEmpty());
        }
    }
}