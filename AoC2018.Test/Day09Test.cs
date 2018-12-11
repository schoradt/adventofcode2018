using System;
namespace AoC2018.Test
{
    using AoC2018.Lib;
    using Xunit;

    public class Day09Test
    {
        [Theory]
        [InlineData("9 players; last marble is worth 25 points", 32)]
        [InlineData("10 players; last marble is worth 1618 points", 8317)]
        [InlineData("13 players; last marble is worth 7999 points", 146373)]
        [InlineData("17 players; last marble is worth 1104 points", 2764)]
        [InlineData("21 players; last marble is worth 6111 points", 54718)]
        [InlineData("30 players; last marble is worth 5907 points", 37305)]
        public void TestPart1(string input, int expected)
        {
            Day09 day09 = new Day09();

            Assert.Equal(expected, day09.Part1(input));
        }

    }
}
