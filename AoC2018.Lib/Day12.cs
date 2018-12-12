using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace AoC2018.Lib
{
    public class Day12
    {
        public Int64 Part1(string[] lines)
        {
            Game g = new Game(lines);

            for (int i = 0; i < 20; i++)
            {
                g.Step();
            }

            return g.SumPlants();
        }

        public Int64 Part2(string[] lines)
        {
            Game g = new Game(lines);

            Int64 runs = 50000000000;

            Dictionary<string, Int64> loops = new Dictionary<string, Int64>();

            for (Int64 i = 0; i < runs; i++)
            {
                g.Step();

                String c = g.GetConf();

                if (loops.ContainsKey(c))
                {
                    Int64 sum = g.SumPlants();

                    return (sum + (sum - loops[c]) * (runs - i - 1));
                }

                loops[c] = g.SumPlants();
            }

            return g.SumPlants();
        }

        public class Game
        {
            Dictionary<Int64, bool> configuration = new Dictionary<Int64, bool>();

            Dictionary<string, bool> rules = new Dictionary<string, bool>();

            public Game(string[] lines)
            {
                string line = lines[0];

                for(int i = 15; i < line.Length; i++)
                {
                    if (line[i] == '#')
                    {
                        configuration[i - 15] = true;
                    }
                    else
                    {
                        configuration[i - 15] = false;
                    }
                }

                for (int i = 2; i < lines.Length; i++)
                {
                    string l = lines[i];

                    int index = l.IndexOf('=');

                    string key = l.Substring(0, index - 1);

                    if (l.Substring(index + 3) == "#")
                    {
                        rules[key] = true;
                    }
                    else
                    {
                        rules[key] = false;
                    }
                }


            }

            public string GetConf()
            {
                StringBuilder b = new StringBuilder();

                Int64 minKey = configuration.Keys.Min();
                Int64 maxKey = configuration.Keys.Max();

                for (Int64 i = minKey; i <= maxKey; i++)
                {
                    if (configuration.TryGetValue(i, out bool value) && value)
                    {
                        b.Append("#");
                    }
                    else
                    {
                        b.Append(".");
                    }
                }

                return b.ToString();
            }

            public void Step()
            {
                string key = ".....";

                Int64 minKey = configuration.Keys.Min();
                Int64 maxKey = configuration.Keys.Max();

                for (Int64 i = minKey - 2; i <= maxKey + 2; i++)
                {
                    key = key.Substring(1);

                    if (configuration.TryGetValue(i + 2, out bool value) && value)
                    {
                        key += "#";
                    }
                    else
                    {
                        key += ".";
                    }

                    if (rules.TryGetValue(key, out value) && value)
                    {
                        //Console.WriteLine("    check " + i + " " + key + " => #");
                        configuration[i] = true;
                    }
                    else
                    {
                        configuration.Remove(i);
                    }
                }
            }

            public Int64 SumPlants()
            {
                Int64 sum = 0;

                foreach(Int64 i in configuration.Keys)
                {
                    if (configuration[i])
                    {
                        sum += i;
                    }
                }

                return sum;
            }
        }

    }
}
