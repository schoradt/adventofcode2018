// <copyright file="Day02.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Lib
{
    using System;

    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The solution for the day 2 of the advent of code 2018.
    /// </summary>
    public class Day02
    {
        /// <summary>
        /// Process the product of the count of product numbers that contains a letter 3 times and the count of product numbers that contains 
        /// a letter 2 times.
        /// </summary>
        /// <returns>The product of the two counts.</returns>
        /// <param name="numbers">The list of product numbers.</param>
        public int Part1(string[] numbers)
        {
            int two = 0;
            int three = 0;

            foreach (string number in numbers)
            {
                PartNumber.Checks check = PartNumber.Checksum(number);

                if (PartNumber.HasLetterTwice(check))
                {
                    two++;
                }

                if (PartNumber.HasLetterThreeTimes(check))
                {
                    three++;
                }
            }

            return two * three;
        }

        /// <summary>
        /// Check for the two product numbers that only differs in one char and return the number without these char.
        /// </summary>
        /// <returns>The product number without the diffing char or an empty string if nothing was found.</returns>
        /// <param name="numbers">A List of product numbers.</param>
        public string Part2(string[] numbers)
        {
            foreach (string numberOne in numbers)
            {
                foreach (string numberTwo in numbers)
                {
                    int pos = PartNumber.DiffOnOnePosition(numberOne, numberTwo);

                    if (pos != -1) 
                    {
                        return PartNumber.RemoveChar(numberOne, pos);
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// The class collects function in the scope  of part numbers. 
        /// </summary>
        public static class PartNumber
        {
            /// <summary>
            /// An enum of check resuluts.
            /// </summary>
            public enum Checks
            {
                /// <summary>
                /// No checksum result.
                /// </summary>
                NONE,

                /// <summary>
                /// The number contains one or more letters exactly twice. 
                /// </summary>
                TWO,

                /// <summary>
                /// The number comntains one or more letters exactly three times.
                /// </summary>
                THREE,

                /// <summary>
                /// The number contains some letters exactly twice and some three times.
                /// </summary>
                BOTH
            }

            /// <summary>
            /// Compute a checksum by checking if a letter is contained two or three times.
            /// </summary>
            /// <returns>A check element.</returns>
            /// <param name="number">The part number to check.</param>
            public static Checks Checksum(string number)
            {
                var map = new Dictionary<char, int>();

                foreach (char c in number)
                {
                    if (map.ContainsKey(c))
                    {
                        map[c] = map[c] + 1;
                    }
                    else
                    {
                        map[c] = 1;
                    }
                }

                int two = 0;
                int three = 0;

                foreach (char c in map.Keys)
                {
                    if (map[c] == 2)
                    {
                        two++;
                    }
                    else if (map[c] == 3)
                    {
                        three++;
                    }
                }

                if (three > 0 && two > 0)
                {
                    return Checks.BOTH;
                }

                if (three > 0)
                {
                    return Checks.THREE;
                }

                if (two > 0)
                {
                    return Checks.TWO;
                }

                return Checks.NONE;
            }

            /// <summary>
            /// Check if the check means a  letter is contained twice.
            /// </summary>
            /// <returns><c>true</c>, if letter twice was hased, <c>false</c> otherwise.</returns>
            /// <param name="check">The checksum result.</param>
            public static Boolean HasLetterTwice(Checks check)
            {
                return check == PartNumber.Checks.TWO || check == PartNumber.Checks.BOTH;
            }

            /// <summary>
            /// Hases the letter three times.
            /// </summary>
            /// <returns><c>true</c>, if letter three times was hased, <c>false</c> otherwise.</returns>
            /// <param name="check">The checksum result.</param>
            public static bool HasLetterThreeTimes(Checks check)
            {
                return check >= PartNumber.Checks.THREE;
            }

            /// <summary>
            /// Checks if the two numbers differs only in one position and returns the position or -1 otherwise.
            /// </summary>
            /// <returns>The diff position or -1.</returns>
            /// <param name="one">First part number.</param>
            /// <param name="two">Second part number.</param>
            public static int DiffOnOnePosition(string one, string two)
            {
                if (one.Length != two.Length)
                {
                    return -1;
                }

                int diff = -1;

                for (int i = 0; i < one.Length; i++)
                {
                    if (one[i] != two[i])
                    {
                        if (diff == -1)
                        {
                            diff = i;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }

                return diff;
            }

            /// <summary>
            /// Removes the char on the given position.
            /// </summary>
            /// <returns>The string without the char.</returns>
            /// <param name="number">The part number.</param>
            /// <param name="index">The char index to remove.</param>
            public static string RemoveChar(string number, int index)
            {
                StringBuilder sb = new StringBuilder(number);
                sb.Remove(index, 1);

                return sb.ToString();
            }
        }
    }
}
