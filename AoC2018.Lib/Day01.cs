using System;
using System.Collections.Generic;

namespace AoC2018.Lib
{
    public class Day01
    {
        public int Part1(string input) {
            string[] freqs = input.Split(',');

            int result = 0;

            foreach (string freq in freqs) {
                Int32 change = Int32.Parse(freq);

                result += change;
            }

            return result;
        }

        public int Part2(string input)
        {
            string[] freqs = input.Split(',');

            var results = new List<int>();

            int result = 0;

            results.Add(result);

            while (true)
            {
                foreach (string freq in freqs)
                {
                    Int32 change = Int32.Parse(freq);

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
