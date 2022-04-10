using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Linq;
using AutoFixture;

namespace Kappa.Extensions.UnitTests
{
    public class EnumerableExtensionsTests
    {
        private readonly Fixture _fixture;

        public EnumerableExtensionsTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void NullOrEmpty_Should_Return_False()
        {
            var enumerable = new List<string> { "test", "demo" };

            enumerable.IsNullOrEmpty().Should().BeFalse();
        }

        [Fact]
        public void NullOrEmpty_Should_Return_True()
        {
            var enumerable = new List<string>();

            enumerable.IsNullOrEmpty().Should().BeTrue();
        }

        [Fact]
        public void NullOrEmpty_For_Null_Enumerable_Should_Return_True()
        {
            IEnumerable<string> enumerable = null;

            enumerable.IsNullOrEmpty().Should().BeTrue();
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

            Assert.True(douplicates.IsNullOrEmpty());
        }

        [Fact]
        public void ToSafeDictionaryOrDefault_Should_Return_Empty_Dictionary()
        {
            var dict = new List<object>
            {

            };

            var safeDict = dict.ToSafeDictionaryOrDefault(x => x, y => y);

            Assert.True(safeDict.IsNullOrEmpty());
        }

        [Fact]
        public void TryGetFirstOrDefault_Should_Return_True()
        {
            var source = new List<int> { 1, 2, 3, 4, 5 };
            var result = source.TryGetFirstOrDefault(out var value);

            Assert.True(result);
            Assert.True(value == source.FirstOrDefault());
        }

        [Fact]
        public void TryGetFirstOrDefault_With_Predicate_Should_Return_True()
        {
            var source = new List<int> { 1, 2, 3, 4, 5 };
            var result = source.TryGetFirstOrDefault(x => x == 2, out var value);

            Assert.True(result);
            Assert.True(value == 2);
        }

        [Fact]
        public void TryGetFirstOrDefault_Should_Return_False()
        {
            var source = new List<int> { };
            var result = source.TryGetFirstOrDefault(out var value);

            Assert.False(result);
            Assert.True(value == default);
        }

        [Fact]
        public void TryGetFirstOrDefault_With_Predicate_Should_Return_False()
        {
            var source = new List<Student>();
            var result = source.TryGetFirstOrDefault(x => x.Id == 20, out var value);

            Assert.False(result);
            Assert.True(value == default);
        }

        [Fact]
        public void Will_calculate_product_of_a_decimal_list()
        {
            var list = _fixture.CreateMany<decimal>(5);

            var product = list.Product();

            var result = 1m;
            foreach (var item in list)
            {
                result *= item;
            }

            Assert.Equal(result, product);
        }

        [Fact]
        public void Will_calculate_product_of_a_double_list()
        {
            var list = _fixture.CreateMany<double>(5);

            var product = list.Product();

            var result = 1d;
            foreach(var item in list)
            {
                result *= item;
            }

            Assert.Equal(result, product);
        }

        [Fact]
        public void Will_calculate_product_of_a_float_list()
        {
            var list = _fixture.CreateMany<float>(5);

            var product = list.Product();

            var result = 1f;
            foreach (var item in list)
            {
                result *= item;
            }

            Assert.Equal(result, product);
        }

        [Fact]
        public void Will_calculate_product_of_an_int_list()
        {
            var list = _fixture.CreateMany<int>(5);

            var product = list.Product();

            var result = 1;
            foreach (var item in list)
            {
                result *= item;
            }

            Assert.Equal(result, product);
        }

        [Fact]
        public void Will_calculate_product_of_a_long_list()
        {
            var list = _fixture.CreateMany<long>(5);

            var product = list.Product();

            var result = 1L;
            foreach (var item in list)
            {
                result *= item;
            }

            Assert.Equal(result, product);
        }

        [Fact]
        public void Will_calculate_zero_product_of_a_decimal_list()
        {
            var list = _fixture.CreateMany<decimal>(5).ToList();
            list.Add(0);

            var product = list.Product();

            Assert.Equal(0, product);
        }

        [Fact]
        public void Will_calculate_zero_product_of_a_double_list()
        {
            var list = _fixture.CreateMany<double>(5).ToList();
            list.Add(0);

            var product = list.Product();

            Assert.Equal(0, product);
        }

        [Fact]
        public void Will_calculate_zero_product_of_a_float_list()
        {
            var list = _fixture.CreateMany<float>(5).ToList();
            list.Add(0);

            var product = list.Product();

            Assert.Equal(0, product);
        }

        [Fact]
        public void Will_calculate_zero_product_of_an_int_list()
        {
            var list = _fixture.CreateMany<int>(5).ToList();
            list.Add(0);

            var product = list.Product();

            Assert.Equal(0, product);
        }

        [Fact]
        public void Will_calculate_zero_product_of_a_long_list()
        {
            var list = _fixture.CreateMany<long>(5).ToList();
            list.Add(0);

            var product = list.Product();

            Assert.Equal(0, product);
        }

        [Fact]
        public void Will_calculate_zero_product_of_an_empty_decimal_list()
        {
            var list = new List<decimal>();

            var product = list.Product();

            Assert.Equal(0, product);
        }

        [Fact]
        public void Will_calculate_zero_product_of_an_empty_double_list()
        {
            var list = new List<double>();

            var product = list.Product();

            Assert.Equal(0, product);
        }

        [Fact]
        public void Will_calculate_zero_product_of_an_empty_float_list()
        {
            var list = new List<float>();

            var product = list.Product();

            Assert.Equal(0, product);
        }

        [Fact]
        public void Will_calculate_zero_product_of_an_empty_int_list()
        {
            var list = new List<long>();

            var product = list.Product();

            Assert.Equal(0, product);
        }

        [Fact]
        public void Will_calculate_zero_product_of_an_empty_long_list()
        {
            var list = new List<long>();

            var product = list.Product();

            Assert.Equal(0, product);
        }

        [Fact]
        public void Will_calculate_product_of_a_nullable_decimal_list()
        {
            var list = _fixture
                .Build<decimal?>()
                .CreateMany(5);

            decimal? result = 1;
            foreach(var item in list)
            {
                result *= item;
            }

            var product = list.Product();

            Assert.Equal(product, result);
        }

        [Fact]
        public void Will_calculate_product_of_a_nullable_double_list()
        {
            var list = _fixture
                .Build<double?>()
                .CreateMany(5);

            double? result = 1;
            foreach (var item in list)
            {
                result *= item;
            }

            var product = list.Product();

            Assert.Equal(product, result);
        }

        [Fact]
        public void Will_calculate_product_of_a_nullable_float_list()
        {
            var list = _fixture
                .Build<float?>()
                .CreateMany(5);

            float? result = 1;
            foreach (var item in list)
            {
                result *= item;
            }

            var product = list.Product();

            Assert.Equal(product, result);
        }

        [Fact]
        public void Will_calculate_product_of_a_nullable_integer_list()
        {
            var list = _fixture
                .Build<int?>()
                .CreateMany(5);

            int? result = 1;
            foreach (var item in list)
            {
                result *= item;
            }

            var product = list.Product();

            Assert.Equal(product, result);
        }

        [Fact]
        public void Will_calculate_product_of_a_nullable_long_list()
        {
            var list = _fixture
                .Build<long?>()
                .CreateMany(5);

            long? result = 1;
            foreach (var item in list)
            {
                result *= item;
            }

            var product = list.Product();

            Assert.Equal(product, result);
        }

        [Fact]
        public void Will_calculate_zero_product_of_a_nullable_decimal_list()
        {
            var list = _fixture
                .Build<decimal?>()
                .CreateMany(5)
                .ToList();

            list.Add(null);

            var product = list.Product();

            Assert.Equal(0, product);
        }

        [Fact]
        public void Will_calculate_zero_product_of_a_nullable_double_list()
        {
            var list = _fixture
                .Build<double?>()
                .CreateMany(5)
                .ToList();

            list.Add(null);

            var product = list.Product();

            Assert.Equal(0, product);
        }

        [Fact]
        public void Will_calculate_zero_product_of_a_nullable_float_list()
        {
            var list = _fixture
                .Build<float?>()
                .CreateMany(5)
                .ToList();

            list.Add(null);

            var product = list.Product();

            Assert.Equal(0, product);
        }

        [Fact]
        public void Will_calculate_zero_product_of_a_nullable_integer_list()
        {
            var list = _fixture
                .Build<int?>()
                .CreateMany(5)
                .ToList();

            list.Add(null);

            var product = list.Product();

            Assert.Equal(0, product);
        }

        [Fact]
        public void Will_calculate_zero_product_of_a_nullable_long_list()
        {
            var list = _fixture
                .Build<long?>()
                .CreateMany(5)
                .ToList();

            list.Add(null);

            var product = list.Product();

            Assert.Equal(0, product);
        }
    }

    class Student
    {
        public int Id { get; set; }
    }
}