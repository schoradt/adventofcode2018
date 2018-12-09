namespace AoC2018.Lib
{
    using System;
    using System.Collections.Generic;

    public class Day09
    {
        public Int64 Part1(string line)
        {
            int players = int.Parse(line.Substring(0, line.IndexOf(' ', 0)));
            int end = int.Parse(line.Substring(line.IndexOf(' ', 0) + 31, line.IndexOf(' ', line.IndexOf(' ', 0) + 31) - line.IndexOf(' ', 0) - 31));

            return Play(players, end);
        }

        public Int64 Part2(string line)
        {
            int players = int.Parse(line.Substring(0, line.IndexOf(' ', 0)));
            int end = int.Parse(line.Substring(line.IndexOf(' ', 0) + 31, line.IndexOf(' ', line.IndexOf(' ', 0) + 31) - line.IndexOf(' ', 0) - 31));

            return Play(players, end * 100);
        }

        private Int64 Play(int players, int end)
        {
            Boolean print = false;

            LinkedList<int> game = new LinkedList<int>();

            Dictionary<int, Int64> result = new Dictionary<int, Int64>();

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

                    //Console.WriteLine("Insert on " + pos);

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

            Int64 max = 0;

            foreach (Int64 v in result.Values)
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
