// <copyright file="Day01Test.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Test
{
    using System;

    using AoC2018.Lib;
    using Xunit;

    /// <summary>
    /// Test for the day 1 exercise.
    /// </summary>
    public class Day01Test
    {
        /// <summary>
        /// Tests the Part1 function. 
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="should">Expected result.</param>
        [Theory]
        [InlineData("+1, +1, +1", 3)]
        [InlineData("+1, +1, -2", 0)]
        [InlineData("-1, -2, -3", -6)]
        public void TestPart1(string input, int should)
        {
            string[] freqs = input.Split(',');

            Day01 day01 = new Day01();

            Assert.Equal(should, day01.Part1(freqs));
        }

        /// <summary>
        /// Tests the Part2 function.
        /// </summary>
        /// <param name="input">Input data.</param>
        /// <param name="should">Expected result.</param>
        [Theory]
        [InlineData("+1, -1", 0)]
        [InlineData("+3, +3, +4, -2, -4", 10)]
        [InlineData("-6, +3, +8, +5, -6", 5)]
        [InlineData("+7, +7, -2, -7, -4", 14)]
        public void TestPart2(string input, int should)
        {
            string[] freqs = input.Split(',');

            Day01 day01 = new Day01();

            Assert.Equal(should, day01.Part2(freqs));
        }
    }
}
