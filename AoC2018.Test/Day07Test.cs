// <copyright file="Day07Test.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Test
{
    using AoC2018.Lib;
    using Xunit;

    /// <summary>
    /// Day07 test.
    /// </summary>
    public class Day07Test
    {
        /// <summary>
        /// Tests the part1.
        /// </summary>
        [Fact]
        public void TestPart1()
        {
            string[] input = new string[]
            {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin."
                };

            Day07 day07 = new Day07();

            Assert.Equal("CABDFE", day07.Part1(input));
        }

        /// <summary>
        /// Tests the part2.
        /// </summary>
        [Fact]
        public void TestPart2()
        {
            string[] input = new string[]
            {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin."
                };

            Day07 day07 = new Day07();

            Assert.Equal(15, day07.Part2(input, 2, 0));
        }
    }
}
