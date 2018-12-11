
namespace AoC2018.Test
{
    using System;
    using System.Collections.Generic;
    using AoC2018.Lib;
    using Xunit;

    public class Day06Test
    {
        [Fact]
        public void TestPart1()
        {
            string[] input = new string[]
            {
                "1, 1",
                "1, 6",
                "8, 3",
                "3, 4",
                "5, 5",
                "8, 9"
                };

            Day06 day06 = new Day06();

            Assert.Equal(17, day06.Part1(input));
        }

        [Fact]
        public void TestPart2()
        {
            string[] input = new string[]
            {
                "1, 1",
                "1, 6",
                "8, 3",
                "3, 4",
                "5, 5",
                "8, 9"
                };

            Day06 day06 = new Day06();

            Assert.Equal(16, day06.Part2(input, 32));
        }
    }
}
