// <copyright file="Day05Test.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Test
{
    using System;
    using System.Collections.Generic;
    using AoC2018.Lib;
    using Xunit;

    /// <summary>
    /// Day05 test.
    /// </summary>
    public class Day05Test
    {
        /// <summary>
        /// Tests the part1.
        /// </summary>
        /// <param name="line">String input.</param>
        /// <param name="expected">Expected result.</param>
        [Theory]
        [InlineData("aA", 0)]
        [InlineData("abBA", 0)]
        [InlineData("abAB", 4)]
        [InlineData("aabAAB", 6)]
        [InlineData("dabAcCaCBAcCcaDA", 10)]
        public void TestPart1(string line, int expected)
        {
            Day05 day05 = new Day05();

            Assert.Equal(expected, day05.Part1(line));
        }

        /// <summary>
        /// Tests the part2.
        /// </summary>
        /// <param name="line">Input line.</param>
        /// <param name="expected">Expected result.</param>
        [Theory]
        [InlineData("dabAcCaCBAcCcaDA", 4)]
        public void TestPart2(string line, int expected)
        {
            Day05 day05 = new Day05();

            Assert.Equal(expected, day05.Part2(line));
        }
    }
}
