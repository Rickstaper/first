using NUnit.Framework;
using static First.GCD;
using System;

namespace First.Tests
{
    class GcdBySteinTests
    {
        [TestCase(50, 250, ExpectedResult = 50)]
        [TestCase(945, 0, ExpectedResult = 945)]
        [TestCase(0, -300, ExpectedResult = 300)]
        [TestCase(2672, 5678, ExpectedResult = 334)]
        public int GetGcdBySteinWithTwoArgumtns (int a, int b) => GetGcdByStein (a, b, out double _);

        [Test]
        public void GetGcdBySteinWithTwoZero_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException> (() => GetGcdByStein (0, 0, out double _), "All arguments cannot be 0");
        }

        [TestCase(int.MinValue, 225)]
        public void GetGcdBySteinWithMinValue_ThrowArgumentOutOfRangeException(int a, int b)
        {
            Assert.Throws<ArgumentOutOfRangeException> (() => GetGcdByStein (a, b, out double _), $"Argument cannot be {int.MinValue}");
        }
    }
}
