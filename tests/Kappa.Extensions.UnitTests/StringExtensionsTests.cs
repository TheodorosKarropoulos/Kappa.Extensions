using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions;

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

        [Theory]
        [InlineData("fsadfs876876")]
        [InlineData("askdfjl32497238sfhksdhfk")]
        public void IsAlphanumeric_Returns_True(string source)
        {
            Assert.True(source.IsAlphanumeric());
        }

        [Theory]
        [InlineData("   ")]
        [InlineData("sdfkajsdhk 92834923&*^*%&^%*")]
        public void IsAlphanumeric_Returns_False(string source)
        {
            Assert.False(source.IsAlphanumeric());
        }

        [Theory]
        [InlineData("sdlkfjlas asldkfjlasd     94093280jfo")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Should_StripAllWhiteSpace_With_Success(string source)
        {
            source.StripAllWhiteSpace().Should().NotContain(" ");
        }

        [Theory]
        [InlineData("this is a demo text")]
        [InlineData("this is a 11111")]
        public void ContainsAny_Return_True(string source)
        {
            var chars = new List<string> { "1", "2", "3", "e" };
            Assert.True(source.ContainsAny(chars));
        }

        [Theory]
        [InlineData("this is a demo text")]
        [InlineData("this is a 11111")]
        public void CountainsAny_Return_False(string source)
        {
            var chars = new List<string> { "y", "z" };
            Assert.False(source.ContainsAny(chars));
        }

        [Theory]
        [InlineData("  ksjdfhlask 12 ")]
        [InlineData("sjdkfsd7876876sdfsdf")]
        [InlineData("4928749 23984293")]
        [InlineData("9847923,,.,.,892347239")]
        public void NotContainNumbers_Should_Return_False(string source)
        {
            source.NotContainNumbers().Should().BeFalse();
        }

        [Theory]
        [InlineData("  ksjdfhlask ")]
        [InlineData("fjashlkfj asfkjsah fk")]
        [InlineData("djgfhsdjkgkdf")]
        [InlineData("kldfjgfdlk&^*&^dfkghkdfjhg,./.,?<?>")]
        public void NotContainNumbers_Should_Return_True(string source)
        {
            source.NotContainNumbers().Should().BeTrue();
        }
    }
}
