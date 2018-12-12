// <copyright file="Day08Test.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Test
{
    using AoC2018.Lib;
    using Xunit;

    /// <summary>
    /// Day08 test.
    /// </summary>
    public class Day08Test
    {
        /// <summary>
        /// Tests the part1.
        /// </summary>
        [Fact]
        public void TestPart1()
        {
            string input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";

            Day08 day08 = new Day08();

            Assert.Equal(138, day08.Part1(input));
        }

        /// <summary>
        /// Tests the part2.
        /// </summary>
        [Fact]
        public void TestPart2()
        {
            string input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";

            Day08 day08 = new Day08();

            Assert.Equal(66, day08.Part2(input));
        }
    }
}
