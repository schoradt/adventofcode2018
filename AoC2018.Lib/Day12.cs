// <copyright file="Day12.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Lib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Day12 solution class.
    /// </summary>
    public class Day12
    {
        /// <summary>
        /// Part one of the solution.
        /// </summary>
        /// <returns>The solution.</returns>
        /// <param name="lines">Inpput lines.</param>
        public long Part1(string[] lines)
        {
            Game g = new Game(lines);

            for (int i = 0; i < 20; i++)
            {
                g.Step();
            }

            return g.SumPlants();
        }

        /// <summary>
        /// Part2 of the puzzles solution.
        /// </summary>
        /// <returns>The solution.</returns>
        /// <param name="lines">Input lines.</param>
        public long Part2(string[] lines)
        {
            Game g = new Game(lines);

            long runs = 50000000000;

            Dictionary<string, long> loops = new Dictionary<string, long>();

            for (long i = 0; i < runs; i++)
            {
                g.Step();

                string c = g.GetConf();

                if (loops.ContainsKey(c))
                {
                    long sum = g.SumPlants();

                    return sum + ((sum - loops[c]) * (runs - i - 1));
                }

                loops[c] = g.SumPlants();
            }

            return g.SumPlants();
        }

        /// <summary>
        /// Game class.
        /// </summary>
        public class Game
        {
            /// <summary>
            /// The configuration.
            /// </summary>
            private readonly Dictionary<long, bool> configuration = new Dictionary<long, bool>();

            /// <summary>
            /// The rules.
            /// </summary>
            private readonly Dictionary<string, bool> rules = new Dictionary<string, bool>();

            /// <summary>
            /// Initializes a new instance of the <see cref="T:AoC2018.Lib.Day12.Game"/> class.
            /// </summary>
            /// <param name="lines">Description lines.</param>
            public Game(string[] lines)
            {
                string line = lines[0];

                for (int i = 15; i < line.Length; i++)
                {
                    if (line[i] == '#')
                    {
                        this.configuration[i - 15] = true;
                    }
                    else
                    {
                        this.configuration[i - 15] = false;
                    }
                }

                for (int i = 2; i < lines.Length; i++)
                {
                    string l = lines[i];

                    int index = l.IndexOf('=');

                    string key = l.Substring(0, index - 1);

                    if (l.Substring(index + 3) == "#")
                    {
                        this.rules[key] = true;
                    }
                    else
                    {
                        this.rules[key] = false;
                    }
                }
            }

            /// <summary>
            /// Gets the actual configuration.
            /// </summary>
            /// <returns>The conf.</returns>
            public string GetConf()
            {
                StringBuilder b = new StringBuilder();

                long minKey = this.configuration.Keys.Min();
                long maxKey = this.configuration.Keys.Max();

                for (long i = minKey; i <= maxKey; i++)
                {
                    if (this.configuration.TryGetValue(i, out bool value) && value)
                    {
                        b.Append("#");
                    }
                    else
                    {
                        b.Append(".");
                    }
                }

                return b.ToString();
            }

            /// <summary>
            /// Run game one step.
            /// </summary>
            public void Step()
            {
                string key = ".....";

                long minKey = this.configuration.Keys.Min();
                long maxKey = this.configuration.Keys.Max();

                for (long i = minKey - 2; i <= maxKey + 2; i++)
                {
                    key = key.Substring(1);

                    if (this.configuration.TryGetValue(i + 2, out bool value) && value)
                    {
                        key += "#";
                    }
                    else
                    {
                        key += ".";
                    }

                    if (this.rules.TryGetValue(key, out value) && value)
                    {
                        this.configuration[i] = true;
                    }
                    else
                    {
                        this.configuration.Remove(i);
                    }
                }
            }

            /// <summary>
            /// Sums the plants.
            /// </summary>
            /// <returns>The plants.</returns>
            public long SumPlants()
            {
                long sum = 0;

                foreach (long i in this.configuration.Keys)
                {
                    if (this.configuration[i])
                    {
                        sum += i;
                    }
                }

                return sum;
            }
        }
    }
}
