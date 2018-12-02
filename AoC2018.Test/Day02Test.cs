// <copyright file="Day02Test.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Test
{
    using AoC2018.Lib;
    using Xunit;

    /// <summary>
    /// Test function for day 2 class.
    /// </summary>
    public class Day02Test
    {
        /// <summary>
        /// Test function for the Part1 function.
        /// </summary>
        [Fact]
        public void TestPart1()
        {
            string[] input = new string[] { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab" };

            Day02 day02 = new Day02();

            Assert.Equal(12, day02.Part1(input));
        }

        /// <summary>
        /// Tests the Part2 function.
        /// </summary>
        [Fact]
        public void TestPart2()
        {
            string[] input = new string[] { "abcde", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz" };

            Day02 day02 = new Day02();

            Assert.Equal("fgij", day02.Part2(input));
        }
    }
}
