using System.Linq;

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

        [Theory]
        [InlineData("sdfsdf123123")]
        [InlineData("23423423")]
        [InlineData("423 sfsd 34")]
        public void GetNumbers_Return_Numbers_Of_String(string str)
        {
            Assert.True(str.GetNumbers().All(x => char.IsDigit(x)));
        }
    }
}
