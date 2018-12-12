// <copyright file="Day11Test.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Test
{
    using AoC2018.Lib;
    using Xunit;

    /// <summary>
    /// Day11 test.
    /// </summary>
    public class Day11Test
    {
        /// <summary>
        /// Tests the power level.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="gsn">Gsn number.</param>
        /// <param name="expected">Expected output.</param>
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

        /// <summary>
        /// Tests the powerful square.
        /// </summary>
        /// <param name="gsn">Gsn number.</param>
        /// <param name="expectedX">Expected x.</param>
        /// <param name="expectedY">Expected y.</param>
        /// <param name="expectedPower">Expected power.</param>
        [Theory]
        [InlineData(18, 33, 45, 0)]
        [InlineData(42, 21, 61, 0)]
        public void TestPowerfulSquare(int gsn, int expectedX, int expectedY, int expectedPower)
        {
            Day11.Result p = new Day11.Result(expectedX, expectedY, 3, expectedPower);

            Day11 day11 = new Day11();

            int[,] raster = day11.CreateRaster(gsn);

            Assert.Equal(p, day11.PowerfulSquare(raster, gsn, 3));
        }

        /// <summary>
        /// Tests the powerful square2.
        /// </summary>
        /// <param name="gsn">Gsn number.</param>
        /// <param name="expectedX">Expected x.</param>
        /// <param name="expectedY">Expected y.</param>
        /// <param name="expectedPower">Expected power.</param>
        [Theory]
        [InlineData(18, 90, 269, 16)]
        [InlineData(42, 232, 251, 12)]
        [InlineData(42, 0, 0, 299)]
        public void TestPowerfulSquare2(int gsn, int expectedX, int expectedY, int expectedPower)
        {
            Day11.Result p = new Day11.Result(expectedX, expectedY, expectedPower, 0);

            Day11 day11 = new Day11();

            int[,] raster = day11.CreateRaster(gsn);

            Assert.Equal(p, day11.PowerfulSquare(raster, gsn, expectedPower));
        }
    }
}
