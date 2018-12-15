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

            //runner.Day01();
            //runner.Day02();
            //runner.Day03();
            //runner.Day04();
            //runner.Day05();
            //runner.Day06();
            //runner.Day07();
            //runner.Day08();
            //runner.Day09();
            //runner.Day10();
            //runner.Day11();
            //runner.Day12();
            //runner.Day13();
            //runner.Day14();
            runner.Day15();
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

        /// <summary>
        /// Process the solutions for day 5.
        /// </summary>
        public void Day05()
        {
            Day05 day05 = new Day05();

            string[] lines = System.IO.File.ReadAllLines(@"data/day05.txt");

            string line = lines[0];

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 05 Part 1: " + day05.Part1(line) + " (" + this.sw.ElapsedMilliseconds + " ms) ");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 05 Part 2: " + day05.Part2(line) + " (" + this.sw.ElapsedMilliseconds + " ms) ");
        }

        /// <summary>
        /// Day06 sulution runner
        /// </summary>
        public void Day06()
        {
            Day06 day06 = new Day06();

            string[] lines = System.IO.File.ReadAllLines(@"data/day06.txt");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 06 Part 1: " + day06.Part1(lines) + " (" + this.sw.ElapsedMilliseconds + " ms) ");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 06 Part 2: " + day06.Part2(lines, 10000) + " (" + this.sw.ElapsedMilliseconds + " ms) ");
        }

        /// <summary>
        /// Day07 solution runner.
        /// </summary>
        public void Day07()
        {
            Day07 day07 = new Day07();

            string[] lines = System.IO.File.ReadAllLines(@"data/day07.txt");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 07 Part 1: " + day07.Part1(lines) + " (" + this.sw.ElapsedMilliseconds + " ms) ");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 07 Part 2: " + day07.Part2(lines, 5, 60) + " (" + this.sw.ElapsedMilliseconds + " ms) ");
        }

        /// <summary>
        /// Day08 solution runner.
        /// </summary>
        public void Day08()
        {
            Day08 day08 = new Day08();

            string[] lines = System.IO.File.ReadAllLines(@"data/day08.txt");
            string line = lines[0];

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 08 Part 1: " + day08.Part1(line) + " (" + this.sw.ElapsedMilliseconds + " ms) ");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 08 Part 2: " + day08.Part2(line) + " (" + this.sw.ElapsedMilliseconds + " ms) ");
        }

        /// <summary>
        /// Day09 solution runner.
        /// </summary>
        public void Day09()
        {
            Day09 day09 = new Day09();

            string[] lines = System.IO.File.ReadAllLines(@"data/day09.txt");
            string line = lines[0];

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 09 Part 1: " + day09.Part1(line) + " (" + this.sw.ElapsedMilliseconds + " ms) ");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 09 Part 2: " + day09.Part2(line) + " (" + this.sw.ElapsedMilliseconds + " ms) ");
        }

        /// <summary>
        /// Day10 solution runner.
        /// </summary>
        public void Day10()
        {
            Day10 day10 = new Day10();

            string[] lines = System.IO.File.ReadAllLines(@"data/day10.txt");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 10 Part 1: \n" + day10.Part1(lines) + "\n (" + this.sw.ElapsedMilliseconds + " ms) ");

            this.sw = Stopwatch.StartNew();

            Console.WriteLine("Day 10 Part 2: " + day10.Part2(lines) + " (" + this.sw.ElapsedMilliseconds + " ms) ");
        }

        /// <summary>
        /// Day11 solution runner.
        /// </summary>
        public void Day11()
        {
            Day11 day11 = new Day11();

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 11 Part 1: " + day11.Part1(9424) + " (" + this.sw.ElapsedMilliseconds + " ms) ");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 11 Part 2: " + day11.Part2(9424) + " (" + this.sw.ElapsedMilliseconds + " ms) ");
        }

        /// <summary>
        /// Day12 solution runner.
        /// </summary>
        public void Day12()
        {
            Day12 day12 = new Day12();

            string[] lines = System.IO.File.ReadAllLines(@"data/day12.txt");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 12 Part 1: " + day12.Part1(lines) + " (" + this.sw.ElapsedMilliseconds + " ms) ");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 12 Part 2: " + day12.Part2(lines) + " (" + this.sw.ElapsedMilliseconds + " ms) ");
        }

        /// <summary>
        /// Day13 solution runner.
        /// </summary>
        public void Day13()
        {
            Day13 day13 = new Day13();

            string[] lines = System.IO.File.ReadAllLines(@"data/day13.txt");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 13 Part 1: " + day13.Part1(lines) + " (" + this.sw.ElapsedMilliseconds + " ms) ");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 13 Part 2: " + day13.Part2(lines) + " (" + this.sw.ElapsedMilliseconds + " ms) ");
        }

        /// <summary>
        /// Day14 solution runner.
        /// </summary>
        public void Day14()
        {
            Day14 day14 = new Day14();

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 14 Part 1: " + day14.Part1(637061) + " (" + this.sw.ElapsedMilliseconds + " ms) ");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 14 Part 2: " + day14.Part2("637061") + " (" + this.sw.ElapsedMilliseconds + " ms) ");
        }

        /// <summary>
        /// Day15 solution runner.
        /// </summary>
        public void Day15()
        {
            Day15 day15 = new Day15();

            string[] lines = System.IO.File.ReadAllLines(@"data/day15.txt");

            this.sw = Stopwatch.StartNew();
            Console.WriteLine("Day 15 Part 1: " + day15.Part1(lines) + " (" + this.sw.ElapsedMilliseconds + " ms) ");

            this.sw = Stopwatch.StartNew();
            //Console.WriteLine("Day 15 Part 2: " + day15.Part2(lines) + " (" + this.sw.ElapsedMilliseconds + " ms) ");
        }
    }
}
