// <copyright file="Day13Test.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Test
{
    using System;
    using AoC2018.Lib;
    using Xunit;

    /// <summary>
    /// Day13 test.
    /// </summary>
    public class Day13Test
    {
        /// <summary>
        /// Tests the part1.
        /// </summary>
        [Fact]
        public void TestPart1()
        {
            string[] input = new string[]
            {
                "/->-\\        ",
                "|   |  /----\\",
                "| /-+--+-\\  |",
                "| | |  | v  |",
                "\\-+-/  \\-+--/",
                "  \\------/   "
                };

            Day13 day13 = new Day13();

            Assert.Equal(new Tuple<int, int>(7, 3), day13.Part1(input));
        }
    
        /// <summary>
        /// Tests the part2.
        /// </summary>
        [Fact]
        public void TestPart2()
        {
            string[] input = new string[]
            {
                "/>-<\\  ",
                "|   |  ",
                "| /<+-\\",
                "| | | v",
                "\\>+</ |",
                "  |   ^",
                "  \\<->/"
                };

            Day13 day13 = new Day13();

            Assert.Equal(new Tuple<int, int>(6, 4), day13.Part2(input));
        }
    }
}
