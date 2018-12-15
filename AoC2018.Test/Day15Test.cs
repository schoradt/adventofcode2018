using System;
namespace AoC2018.Test
{
    using System;
    using AoC2018.Lib;
    using Xunit;

    public class Day15Test
    {
        /// <summary>
        /// Tests the part1.
        /// </summary>
        [Theory]
        [InlineData("#######\n#.G...#\n#...EG#\n#.#.#G#\n#..G#E#\n#.....#\n#######", 27730)]
        [InlineData("#######\n#G..#E#\n#E#E.E#\n#G.##.#\n#...#E#\n#...E.#\n#######", 36334)]
        [InlineData("#######\n#E..EG#\n#.#G.E#\n#E.##E#\n#G..#.#\n#..E#.#\n#######", 39514)]
        [InlineData("#######\n#E.G#.#\n#.#G..#\n#G.#.G#\n#G..#.#\n#...E.#\n#######", 27755)]
        [InlineData("#######\n#.E...#\n#.#..G#\n#.###.#\n#E#G#G#\n#...#G#\n#######", 28944)]
        [InlineData("#########\n#G......#\n#.E.#...#\n#..##..G#\n#...##..#\n#...#...#\n#.G...G.#\n#.....G.#\n#########", 18740)]
        public void TestPart1(string input, int expected)
        {
            string[] lines = input.Split('\n');

            Day15 day15 = new Day15();

            Assert.Equal(expected, day15.Part1(lines));
        }
    }
}
