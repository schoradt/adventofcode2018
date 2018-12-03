
namespace AoC2018.Test
{
    using System;
    using System.Collections.Generic;
    using AoC2018.Lib;
    using Xunit;

    public class Day03Test
    {
        [Fact]
        public void TestPart1()
        {
            string[] input = new string[] { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" };

            Day03 day03 = new Day03();

            Assert.Equal(4, day03.Part1(input));
        }

        [Fact]
        public void TestPart2()
        {
            string[] input = new string[] { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" };

            Day03 day03 = new Day03();

            Assert.Equal(3, day03.Part2(input));
        }

    }
}
