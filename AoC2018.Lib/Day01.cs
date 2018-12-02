// <copyright file="Day01.cs">
//     GPL v3
// </copyright>
// <author>Me</author>

namespace AoC2018.Lib
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Day 1 sollution for the advent of code.
    /// </summary>
    public class Day01
    {
        /// <summary>
        /// Compute the resulting frequency starting from 0 by a list of frequency changes.
        /// </summary>
        /// <returns>The reulting frequency</returns>
        /// <param name="freqs">The list of frequency changes.</param>
        public int Part1(string[] freqs)
        {
            int result = 0;

            foreach (string freq in freqs)
            {
                int change = int.Parse(freq);

                result += change;
            }

            return result;
        }

        /// <summary>
        /// Return the first frequency that is reached twice by the given frequency changes.
        /// </summary>
        /// <returns>The frequency reached twice.</returns>
        /// <param name="freqs">List of frequency changes.</param>
        public int Part2(string[] freqs)
        {
            var results = new HashSet<int>();

            int result = 0;

            results.Add(result);

            while (true)
            {
                foreach (string freq in freqs)
                {
                    int change = int.Parse(freq);

                    result += change;

                    if (results.Contains(result))
                    {
                        return result;
                    }

                    results.Add(result);
                }
            }
        }
    }
}
