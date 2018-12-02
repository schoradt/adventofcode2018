// <copyright file="Runner.cs">
//     GPL v3
// </copyright>
// <author>Me</author>

namespace AoC2018
{
    using System;

    using AoC2018.Lib;

    /// <summary>The file contains the Runner for the advent of code solutions.</summary>
    public class Runner
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Advent of code 2018");
            Console.WriteLine("===================");
            Console.WriteLine();

            Runner runner = new Runner();

            runner.Day01();
            runner.Day02();
        }

        /// <summary>
        /// Process the work for day 1 sollution.
        /// </summary>
        public void Day01()
        {
            Day01 day01 = new Day01();

            string[] lines = System.IO.File.ReadAllLines(@"data/day01.txt");

            Console.WriteLine("Day 01 Part 1: " + day01.Part1(lines));
            Console.WriteLine("Day 01 Part 2: " + day01.Part2(lines));
        }

        /// <summary>
        /// Process the work for day 2 solution.
        /// </summary>
        public void Day02()
        {
            Day02 day02 = new Day02();

            string[] lines = System.IO.File.ReadAllLines(@"data/day02.txt");

            Console.WriteLine("Day 02 Part 1: " + day02.Part1(lines));
            Console.WriteLine("Day 01 Part 2: " + day02.Part2(lines));
        }
    }
}
