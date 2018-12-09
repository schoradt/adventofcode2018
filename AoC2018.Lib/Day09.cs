using System;
using System.Collections.Generic;
using System.Linq;
namespace AoC2018.Lib
{
    public class Day09
    {
        public int Part1(string line)
        {
            Console.WriteLine("line '" + line + "'");

            int players = int.Parse(line.Substring(0, line.IndexOf(' ', 0)));
            int end = int.Parse(line.Substring(line.IndexOf(' ', 0) + 31, line.IndexOf(' ', line.IndexOf(' ', 0) + 31) - line.IndexOf(' ', 0) - 31));

            return Play(players, end);
        }

        public int Part2(string line)
        {
            Console.WriteLine("line '" + line + "'");

            int players = int.Parse(line.Substring(0, line.IndexOf(' ', 0)));
            int end = int.Parse(line.Substring(line.IndexOf(' ', 0) + 31, line.IndexOf(' ', line.IndexOf(' ', 0) + 31) - line.IndexOf(' ', 0) - 31));

            return Play(players, end * 100);
        }

        private int Play(int players, int end)
        {
            Console.WriteLine("game " + players + " " + end);

            List<int> game = new List<int>(end + 1);

            Dictionary<int, int> result = new Dictionary<int, int>();

            for (int j = 0; j < players; j++)
            {
                result[j + 1] = 0;
            }

            game.Add(0);

            int pos = 0;

            int player = 0;

            for (int i = 1; i <= end; i++)
            {
                if (i % 10000 == 0)
                {
                    Console.WriteLine(i + " / " + end);
                }

                player++;

                if (player > players)
                {
                    player = 1;
                }

                // print game
                //Console.Write("[" + player + "] ");

                //for (int j = 0; j < game.Count; j++)
                //{
                //    if (j == pos)
                //    {
                //        Console.Write("(" + game[j] + ")");
                //    }
                //    else
                //    {
                //        Console.Write(" " + game[j] + " ");
                //    }
                //}

                //Console.WriteLine();

                if (i % 23 == 0)
                {
                    pos = mod(pos - 7, game.Count);

                    //Console.WriteLine("Remove on " + pos);

                    result[player] = result[player] + i + game[pos];

                    game.RemoveAt(pos);
                }
                else
                {
                    if (game.Count == 1)
                    {
                        pos = 1;
                    }
                    else
                    {
                        pos = mod(pos + 2, game.Count);
                    }

                    if (pos == 0)
                    {
                        pos = game.Count;
                    }

                    //Console.WriteLine("Insert on " + pos);

                    game.Insert(pos, i);
                }
            }

            int max = 0;

            foreach (int v in result.Values)
            {
                if (v > max)
                {
                    max = v;
                }
            }

            return max;

        }

        int mod(int x, int m)
        {
            return (x % m + m) % m;
        }
    }
}
