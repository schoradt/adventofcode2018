using System;
namespace AoC2018.Test
{
    using AoC2018.Lib;
    using Xunit;

    public class Day14Test
    {
        [Theory]
        [InlineData(5, "0124515891")]
        [InlineData(9, "5158916779")]
        [InlineData(18, "9251071085")]
        [InlineData(2018, "5941429882")]
        public void TestPart1(int x, string expected)
        {
            Day14 day14 = new Day14();

            Assert.Equal(expected, day14.Part1(x));
        }

        [Theory]
        [InlineData("51589", 9)]
        [InlineData("01245", 5)]
        [InlineData("92510", 18)]
        [InlineData("59414", 2018)]
        public void TestPart2(string input, int expected)
        {
            Day14 day14 = new Day14();

            Assert.Equal(expected, day14.Part2(input));
        }

    }
}
