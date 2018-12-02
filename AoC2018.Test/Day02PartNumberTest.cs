// <copyright file="Day02PartNumberTest.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Test
{
    using System;
    using AoC2018.Lib;
    using Xunit;

    /// <summary>
    /// The tests for the part number class.
    /// </summary>
    public class Day02PartNumberTest
    {
        /// <summary>
        /// Tests of the checksum function.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="should">Expected reult.</param>
        [Theory]
        [InlineData("abcdef", Day02.PartNumber.Checks.NONE)]
        [InlineData("bababc", Day02.PartNumber.Checks.BOTH)]
        [InlineData("abbcde", Day02.PartNumber.Checks.TWO)]
        [InlineData("abcccd", Day02.PartNumber.Checks.THREE)]
        [InlineData("aabcdd", Day02.PartNumber.Checks.TWO)]
        [InlineData("abcdee", Day02.PartNumber.Checks.TWO)]
        [InlineData("ababab", Day02.PartNumber.Checks.THREE)]
        public void TestChecksum(string input, Day02.PartNumber.Checks should)
        {
            Assert.Equal(should, Day02.PartNumber.Checksum(input));
        }

        /// <summary>
        /// Test the diff function.
        /// </summary>
        /// <param name="one">String one.</param>
        /// <param name="two">String two.</param>
        /// <param name="should">Expected result.</param>
        [Theory]
        [InlineData("abcdef", "abcdef", -1)]
        [InlineData("sbcdef", "abcdef", 0)]
        [InlineData("ascdef", "abcdef", 1)]
        [InlineData("abddef", "abcdef", 2)]
        [InlineData("abceef", "abcdef", 3)]
        [InlineData("abcdff", "abcdef", 4)]
        [InlineData("abcdee", "abcdef", 5)]
        [InlineData("aacdff", "abcdef", -1)]
        [InlineData("abcdefxxxx", "abcdef", -1)]
        public void TestDiff(string one, string two, int should)
        {
            Assert.Equal(should, Day02.PartNumber.DiffOnOnePosition(one, two));
        }
    }
}
