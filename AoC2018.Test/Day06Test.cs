// <copyright file="Day06Test.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Test
{
    using AoC2018.Lib;
    using Xunit;

    /// <summary>
    /// Day06 test.
    /// </summary>
    public class Day06Test
    {
        /// <summary>
        /// Tests the part1.
        /// </summary>
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

        /// <summary>
        /// Tests the part2.
        /// </summary>
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
