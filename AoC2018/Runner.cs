// <copyright file="Runner.cs">
//     GPL v3
// </copyright>
// <author>Me</author>

namespace AoC2018
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using AoC2018.Lib;

    /// <summary>The file contains the Runner for the advent of code solutions.</summary>
    public class Runner
    {
        /// <summary>
        /// Stopwatch for  function timing.
        /// </summary>
        private Stopwatch sw;

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
            runner.Day03();
            runner.Day04();
        }

        /// <summary>
        /// Process the work for day 1 sollution.
        /// </summary>
        public void Day01()
        {
            Day01 day01 = new Day01();

            string[] lines = System.IO.File.ReadAllLines(@"data/day01.txt");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 01 Part 1: " + day01.Part1(lines) + " (" + this.sw.ElapsedMilliseconds + " ms) ");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 01 Part 2: " + day01.Part2(lines) + " (" + this.sw.ElapsedMilliseconds + " ms) ");
        }

        /// <summary>
        /// Process the work for day 2 solution.
        /// </summary>
        public void Day02()
        {
            Day02 day02 = new Day02();

            string[] lines = System.IO.File.ReadAllLines(@"data/day02.txt");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 02 Part 1: " + day02.Part1(lines) + " (" + this.sw.ElapsedMilliseconds + " ms) ");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 02 Part 2: " + day02.Part2(lines) + " (" + this.sw.ElapsedMilliseconds + " ms) ");
        }

        /// <summary>
        /// Process the work for day 3 solution.
        /// </summary>
        public void Day03()
        {
            Day03 day03 = new Day03();

            string[] lines = System.IO.File.ReadAllLines(@"data/day03.txt");

            this.sw = Stopwatch.StartNew();
            List<Day03.Claim> claims = day03.ParseClaims(lines);

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 03 Part 1: " + day03.Part1(claims) + " (" + this.sw.ElapsedMilliseconds + " ms) ");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 03 Part 2: " + day03.Part2(claims) + " (" + this.sw.ElapsedMilliseconds + " ms) ");
        }

        /// <summary>
        /// Process the solutions for day 4.
        /// </summary>
        public void Day04()
        {
            Day04 day04 = new Day04();

            string[] lines = System.IO.File.ReadAllLines(@"data/day04.txt");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 04 Part 1: " + day04.Part1(lines) + " (" + this.sw.ElapsedMilliseconds + " ms) ");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 04 Part 2: " + day04.Part2(lines) + " (" + this.sw.ElapsedMilliseconds + " ms) ");
        }
    }
}
