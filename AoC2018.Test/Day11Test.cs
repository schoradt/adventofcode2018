using System;
namespace AoC2018.Test
{
    using AoC2018.Lib;
    using Xunit;

    public class Day11Test
    {
        [Theory]
        [InlineData(3, 5, 8, 4)]
        [InlineData(122, 79, 57, -5)]
        [InlineData(217, 196, 39, 0)]
        [InlineData(101, 153, 71, 4)]
        public void TestPowerLevel(int x, int y, int gsn, int expected)
        {
            Day11 day11 = new Day11();

            Assert.Equal(expected, day11.ComutePowerLevel(x, y, gsn));
        }

        [Theory]
        [InlineData(18, 33, 45)]
        [InlineData(42, 21, 61)]
        public void TestPowerfulSquare(int gsn, int expectedX, int expectedY)
        {
            Tuple<int, int> p = new Tuple<int, int>(expectedX, expectedY);

            Day11 day11 = new Day11();

            Assert.Equal(p, day11.PowerfulSquare(gsn));
        }
    }
}
