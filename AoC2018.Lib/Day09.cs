// <copyright file="Day09.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Lib
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Day09 solution class.
    /// </summary>
    public class Day09
    {
        /// <summary>
        /// Solution of part 1 of the puzzle.
        /// </summary>
        /// <returns>The part1.</returns>
        /// <param name="line">Input line.</param>
        public long Part1(string line)
        {
            int players = int.Parse(line.Substring(0, line.IndexOf(' ', 0)));
            int end = int.Parse(line.Substring(line.IndexOf(' ', 0) + 31, line.IndexOf(' ', line.IndexOf(' ', 0) + 31) - line.IndexOf(' ', 0) - 31));

            return this.Play(players, end);
        }

        /// <summary>
        /// Solution of part 2.
        /// </summary>
        /// <returns>The part2.</returns>
        /// <param name="line">Input line.</param>
        public long Part2(string line)
        {
            int players = int.Parse(line.Substring(0, line.IndexOf(' ', 0)));
            int end = int.Parse(line.Substring(line.IndexOf(' ', 0) + 31, line.IndexOf(' ', line.IndexOf(' ', 0) + 31) - line.IndexOf(' ', 0) - 31));

            return this.Play(players, end * 100);
        }

        /// <summary>
        /// Play the specified players and end.
        /// </summary>
        /// <returns>The play.</returns>
        /// <param name="players">Number of players.</param>
        /// <param name="end">End value.</param>
        private long Play(int players, int end)
        {
            bool print = false;

            LinkedList<int> game = new LinkedList<int>();

            Dictionary<int, long> result = new Dictionary<int, long>();

            for (int j = 0; j < players; j++)
            {
                result[j + 1] = 0;
            }

            game.AddFirst(0);

            LinkedListNode<int> pos = game.First;
            LinkedListNode<int> tmp;

            int player = 0;

            // print game
            if (print)
            {
                Console.Write("[" + player + "] ");

                for (tmp = game.First; tmp != null; tmp = tmp.Next)
                {
                    if (tmp == pos)
                    {
                        Console.Write("(" + tmp.Value + ")");
                    }
                    else
                    {
                        Console.Write(" " + tmp.Value + " ");
                    }
                }

                Console.WriteLine();
            }

            for (int i = 1; i <= end; i++)
            {
                player++;

                if (player > players)
                {
                    player = 1;
                }

                if (i % 23 == 0)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        if (pos.Previous == null)
                        {
                            pos = game.Last;
                        }
                        else
                        {
                            pos = pos.Previous;
                        }
                    }

                    result[player] = result[player] + i + pos.Value;

                    tmp = pos.Next;

                    game.Remove(pos);

                    pos = tmp;

                    if (pos == null)
                    {
                        pos = game.First;
                    }
                }
                else
                {
                    pos = pos.Next;

                    if (pos == null)
                    {
                        pos = game.First;
                    }

                    game.AddAfter(pos, i);

                    pos = pos.Next;
                }

                // print game
                if (print)
                {
                    Console.Write("[" + player + "] ");

                    for (tmp = game.First; tmp != null; tmp = tmp.Next)
                    {
                        if (tmp == pos)
                        {
                            Console.Write("(" + tmp.Value + ")");
                        }
                        else
                        {
                            Console.Write(" " + tmp.Value + " ");
                        }
                    }

                    Console.WriteLine();
                }
            }

            long max = 0;

            foreach (long v in result.Values)
            {
                if (v > max)
                {
                    max = v;
                }
            }

            return max;
        }

        /// <summary>
        /// Mod the specified x and m.
        /// </summary>
        /// <returns>The mod.</returns>
        /// <param name="x">Number value.</param>
        /// <param name="m">Modulo value</param>
        private int Mod(int x, int m)
        {
            return ((x % m) + m) % m;
        }
    }
}
