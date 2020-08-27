using Xunit;

namespace Kappa.Extensions.UnitTests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void IsNullOrEmpty_Return_True(string str)
        {
            Assert.True(str.IsNullOrEmpty());
        }

        [Theory]
        [InlineData("    ")]
        [InlineData("   ")]
        [InlineData("ueyiruy   23487293487  ")]
        public void IsNullOrEmpty_Return_False(string str)
        {
            Assert.False(str.IsNullOrEmpty());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void IsNullOrWhiteSpace_Return_True(string str)
        {
            Assert.True(str.IsNullOrWhiteSpace());
        }

        [Theory]
        [InlineData("hfksdhf 23487239")]
        [InlineData("2834792384")]
        [InlineData("  adfhskdj ")]
        public void IsNullOrWhiteSpace_Return_False(string str)
        {
            Assert.False(str.IsNullOrWhiteSpace());
        }
    }
}
