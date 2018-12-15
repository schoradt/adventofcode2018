// <copyright file="Day14.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Lib
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Day14
    {
        public string Part1(int nextTenFrom)
        {
            Kitchen kitchen = new Kitchen();

            do
            {
                kitchen.Cook();
            }
            while (!kitchen.MoreRecipesThen(nextTenFrom + 10));

            return kitchen.NextTenScores(nextTenFrom);
        }

        public int Part2(string sequence)
        {
            Kitchen kitchen = new Kitchen(sequence);

            int position = -1;

            Stopwatch sw = Stopwatch.StartNew();

            do
            {
                kitchen.Cook();

                position = kitchen.TestScoreSequence();
            }
            while (position < 0);

            return position;
        }

        public class Kitchen
        {
            List<int> recipes = new List<int>();

            int elve1 = 0;
            int elve2 = 1;

            List<int> test = new List<int>();

            public Kitchen()
            {
                recipes.Add(3);
                recipes.Add(7);
            }

            public Kitchen(string sequence)
            {
                recipes.Add(3);
                recipes.Add(7);

                foreach (char c in sequence)
                {
                    test.Add(int.Parse("" + c));
                }

                test.Reverse();
            }

            public void Cook()
            {
                int score = recipes[elve1] + recipes[elve2];

                if (score >= 10)
                {
                    int score1 = (score / 10) % 10;

                    recipes.Add(score1);
                }

                int score2 = score % 10;

                recipes.Add(score2);

                elve1 = (elve1 + 1 + recipes[elve1]) % recipes.Count;
                elve2 = (elve2 + 1 + recipes[elve2]) % recipes.Count;
            }

            public string NextTenScores(int start)
            {
                string res = "";

                if (recipes.Count < start + 10)
                {
                    return "";
                }

                for (int i = start; i < start + 10; i++)
                {
                    res += recipes[i];
                }

                return res;
            }

            public void Debug()
            {
                for (int i = 0; i<recipes.Count; i++)
                {
                    if (i == elve1)
                    {
                        Console.Write("(");
                    }
                    else if (i == elve2)
                    {
                        Console.Write("[");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                    Console.Write(recipes[i]);

                    if (i == elve2)
                    {
                        Console.Write("]");
                    }
                    else if (i == elve1)
                    {
                        Console.Write(")");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }

            internal bool MoreRecipesThen(int v)
            {
                return recipes.Count > v;
            }

            internal int TestScoreSequence()
            {
                int pos = 0;

                if (recipes.Count < test.Count)
                {
                    return -1;
                }

                for (int i = recipes.Count - 1; i >= Math.Max(0, recipes.Count - 10); i--)
                {
                    if (recipes[i] == test[pos])
                    {
                        pos++;
                    }
                    else
                    {
                        pos = 0;
                    }

                    if (pos == test.Count)
                    {
                        return i;
                    }
                }

                return -1;
            }
        }
    }
}
