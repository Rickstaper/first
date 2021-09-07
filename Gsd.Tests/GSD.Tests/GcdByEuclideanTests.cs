using NUnit.Framework;
using static First.GCD;
using System;

namespace First.Tests
{
    public class GcdByEuclideanTests
    {
        [TestCase (-7, -7, ExpectedResult = 7)]
        [TestCase (18, 0, ExpectedResult = 18)]
        [TestCase (30, 12, ExpectedResult = 6)]
        [TestCase (30, 12, ExpectedResult = 6)]
        [TestCase (45612, 32251, ExpectedResult = 1)]
        public int GetGcdByEuclideanWithTwoArguments (int a, int b) => GetGcdByEuclidean (a, b, out double _);

        [TestCase(50, 10, -7, ExpectedResult = 1)]
        [TestCase(3, 4, 12, ExpectedResult = 1)]
        [TestCase(-10, -2, -3, ExpectedResult = 1)]
        [TestCase(100, 60, 40, ExpectedResult = 20)]
        [TestCase(15, 5, 45, ExpectedResult = 5)]
        [TestCase(100, 60, 16, ExpectedResult = 4)]
        public int GetGcdByEuclideanWithThreeArguments (int a, int b, int c) => GetGcdByEuclidean (a, b, c);

        [TestCase(0, 1, 0, 0, ExpectedResult = 1)]
        [TestCase(5, 15, 30, 60, ExpectedResult = 5)]
        public int GetGcdByEuclideanWithFourArguments (int a, int b, params int[] other) => GetGcdByEuclidean (a, b, other);

        [TestCase(-10, 35, 90, 55, -105, ExpectedResult = 5)]
        public int GetGcdByEuclideanWithFiveArguments (int a, int b, params int[] other) => GetGcdByEuclidean (a, b, other);

        [Test]
        public void GetGcdByEuclideanWithTwoZeroNumbers_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException> (() => GetGcdByEuclidean (0, 0, out double _), "All arguments cannot be 0");
        }

        [Test]
        public void GetGcdByEuclideanWithThreeZeroNumbers_ThrowArgumentException ()
        {
            Assert.Throws<ArgumentException> (() => GetGcdByEuclidean (0, 0, 0), "All arguments cannot be 0");
        }

        [Test]
        public void GetGcdByEuclideanWithFiveZeroNumbers_ThrowArgumentException ()
        {
            Assert.Throws<ArgumentException> (() => GetGcdByEuclidean (0, 0, 0, 0, 0), "All arguments cannot be 0");
        }

        [TestCase(int.MinValue, 10)]
        public void GetGcdByEuclideanWithMinValue_ThrowArgumentOutOfRangeException(int a, int b)
        {
            Assert.Throws<ArgumentOutOfRangeException> (() => GetGcdByEuclidean (a, b), $"Argument cannot be {int.MinValue}");
        }
    }
}