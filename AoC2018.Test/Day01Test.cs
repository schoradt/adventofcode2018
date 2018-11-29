using System;
using Xunit;
using AoC2018.Lib;

namespace AoC2018.Test
{
    public class Day01Test
    {
        [Theory]
        [InlineData("Test", "test")]
        [InlineData("test", "test")]
        [InlineData("TEST", "test")]
        public void TestPart1(String input, String should)
        {
            Day01 day01 = new Day01();

            Assert.Equal(should, day01.Part1(input));
        }
    }
}
