using System.Collections.Generic;
using Xunit;
using FluentAssertions;

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
    }
}