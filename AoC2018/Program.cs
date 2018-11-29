using System;

using AoC2018.Lib;

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
        }

        public void Day01() {
            Day01 day01 = new Day01();

            Console.WriteLine("Day 01 Part 1: " + day01.Part1("Test"));
            Console.WriteLine("Day 01 Part 2: " + day01.Part2("Test"));
        }
    }
}
