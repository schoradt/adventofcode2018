using System;

using AoC2018.Lib;
using System.Linq;

namespace AoC2018
{
    class Runner
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of code 2018");
            Console.WriteLine("===================");
            Console.WriteLine();

            Runner runner = new Runner();

            runner.Day01();
            runner.Day02();
        }

        public void Day01() {
            Day01 day01 = new Day01();

            string[] lines = System.IO.File.ReadAllLines(@"data/day01.txt");

            string input = String.Join(", ", lines);

            Console.WriteLine("Day 01 Part 1: " + day01.Part1(input));
            Console.WriteLine("Day 01 Part 2: " + day01.Part2(input));
        }

        public void Day02()
        {
            Day02 day02 = new Day02();

            string[] lines = System.IO.File.ReadAllLines(@"data/day02.txt");

            string input = String.Join("\n", lines);

            Console.WriteLine("Day 02 Part 1: " + day02.Part1(input));
            Console.WriteLine("Day 01 Part 2: " + day02.Part2(input));
        }
    }
}
