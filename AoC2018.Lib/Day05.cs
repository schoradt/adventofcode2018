// <copyright file="Day05.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>
using System;

namespace AoC2018.Lib
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Day05 solution.
    /// </summary>
    public class Day05
    {
        /// <summary>
        /// Reduce the string with the given rules.
        /// </summary>
        /// <returns>The length of vthe reduced string.</returns>
        /// <param name="line">The fabric structure.</param>
        public int Part1(string line)
        {
            HashSet<char> chars = new HashSet<char>();

            foreach (char c in line)
            {
                chars.Add(char.ToLower(c));
            }

            int count;

            do
            {
                count = line.Count();

                foreach (char c in chars)
                {
                    line = line.Replace("" + c + char.ToUpper(c), string.Empty);
                    line = line.Replace("" + char.ToUpper(c) + c, string.Empty);
                }
            }
            while (count > line.Count() && line.Any());

            return line.Count();
        }

        /// <summary>
        /// Remove each element and check with removed fabric give the shortest reduction.
        /// </summary>
        /// <returns>The length of the shortest reduction.</returns>
        /// <param name="line">The fabrics structure.</param>
        public int Part2(string line)
        {
            HashSet<char> chars = new HashSet<char>();

            foreach (char c in line)
            {
                chars.Add(char.ToLower(c));
            }

            int min = int.MaxValue;

            foreach (char remove in chars)
            {
                string testLine = line;

                testLine = testLine.Replace("" + remove, string.Empty);
                testLine = testLine.Replace("" + char.ToUpper(remove), string.Empty);

                int react = this.Part1(testLine);

                if (react < min)
                {
                    min = react;
                }
            }

            return min;
        }
    }
}
