using System;
using Xunit;
using AoC2018.Lib;

namespace AoC2018.Test
{
    public class Day02Test
    {
        [Theory]
        [InlineData("abcdef", Day02.Checks.NONE)]
        [InlineData("bababc", Day02.Checks.BOTH)]
        [InlineData("abbcde", Day02.Checks.TWO)]
        [InlineData("abcccd", Day02.Checks.THREE)]
        [InlineData("aabcdd", Day02.Checks.TWO)]
        [InlineData("abcdee", Day02.Checks.TWO)]
        [InlineData("ababab", Day02.Checks.THREE)]
        public void TestChecksum(String input, Day02.Checks should)
        {
            Day02 day02 = new Day02();

            Assert.Equal(should, day02.Checksum(input));
        }

        [Fact]
        public void TestPart1()
        {
            string input = "abcdef\n" +
                "bababc\n" +
                "abbcde\n" +
                "abcccd\n" +
                "aabcdd\n" +
                "abcdee\n" +
                "ababab\n";

            Day02 day02 = new Day02();

            Assert.Equal(12, day02.Part1(input));
        }

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
        public void TestDiff(String one, String two, int should)
        {
            Day02 day02 = new Day02();

            Assert.Equal(should, day02.DiffOnOnePosition(one, two));
        }

        [Fact]
        public void TestPart2()
        {
            string input = "abcde\n" +
                "fghij\n" +
                "klmno\n" +
                "pqrst\n" +
                "fguij\n" +
                "axcye\n" +
                "wvxyz";

            Day02 day02 = new Day02();

            Assert.Equal("fgij", day02.Part2(input));
        }
    }
}
