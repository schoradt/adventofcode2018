// <copyright file="Day05.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

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
            int count = line.Count();

            do
            {
                count = line.Count();

                StringBuilder sb = new StringBuilder();
                int i;

                for (i = 0; i < count - 1; i++)
                {
                    if (line[i] != line[i + 1] && char.ToUpper(line[i]) == char.ToUpper(line[i + 1]))
                    {
                        // remove 
                        i++;
                    }
                    else
                    {
                        sb.Append(line[i]);
                    }
                }

                if (i < count)
                {
                    sb.Append(line[i]);
                }

                line = sb.ToString();
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

                StringBuilder sb = new StringBuilder();

                foreach (char c in line)
                {
                    if (!(c == remove || c == char.ToUpper(remove)))
                    {
                        sb.Append(c);
                    } 
                }

                int react = this.Part1(sb.ToString());

                if (react < min)
                {
                    min = react;
                }
            }

            return min;
        }
    }
}
