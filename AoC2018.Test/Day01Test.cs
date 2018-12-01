using System;
using Xunit;
using AoC2018.Lib;

namespace AoC2018.Test
{
    public class Day01Test
    {
        [Theory]
        [InlineData("+1, +1, +1", 3)]
        [InlineData("+1, +1, -2", 0)]
        [InlineData("-1, -2, -3", -6)]
        public void TestPart1(String input, int should)
        {
            Day01 day01 = new Day01();

            Assert.Equal(should, day01.Part1(input));
        }

        [Theory]
        [InlineData("+1,  -1", 0)]
        [InlineData("+3, +3, +4, -2, -4", 10)]
        [InlineData("-6, +3, +8, +5, -6", 5)]
        [InlineData("+7, +7, -2, -7, -4", 14)]
        public void TestPart2(String input, int should)
        {
            Day01 day01 = new Day01();

            Assert.Equal(should, day01.Part2(input));
        }

    }
}
