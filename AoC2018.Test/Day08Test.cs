using System;
namespace AoC2018.Test
{
    using AoC2018.Lib;
    using Xunit;

    public class Day08Test
    {
        [Fact]
        public void TestPart1()
        {
            string input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";

            Day08 day08 = new Day08();

            Assert.Equal(138, day08.Part1(input));
        }

        [Fact]
        public void TestPart2()
        {
            string input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";

            Day08 day08 = new Day08();

            Assert.Equal(66, day08.Part2(input));
        }
    }
}
