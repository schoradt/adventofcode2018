// <copyright file="Day12Test.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Test
{
    using AoC2018.Lib;
    using Xunit;

    /// <summary>
    /// Day12 test.
    /// </summary>
    public class Day12Test
    {
        /// <summary>
        /// Tests the part1.
        /// </summary>
        [Fact]
        public void TestPart1()
        {
            string[] input = new string[]
            {
                "initial state: #..#.#..##......###...###",
                string.Empty,
                "...## => #",
                "..#.. => #",
                ".#... => #",
                ".#.#. => #",
                ".#.## => #",
                ".##.. => #",
                ".#### => #",
                "#.#.# => #",
                "#.### => #",
                "##.#. => #",
                "##.## => #",
                "###.. => #",
                "###.# => #",
                "####. => #"
                };

            Day12 day12 = new Day12();

            Assert.Equal(325, day12.Part1(input));
        }
    }
}
