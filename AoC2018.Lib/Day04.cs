
namespace AoC2018.Lib
{
    using System;
    using System.Collections.Generic;

    public class Day04
    {
        public int Part1(string[] lines)
        {
            Dictionary<int, Dictionary<int, int>> check = ComputeCheck(lines);

            // compute guard sums
            int guard = 0;
            int max = 0;

            foreach (var item in check) {
                int sum = 0;

                foreach (var guardMin in item.Value) {
                    sum += guardMin.Value;
                }

                Console.WriteLine("sum " + item.Key + " => " + sum);

                if (sum > max) 
                {
                    guard = item.Key;
                    max = sum;
                }
            }

            int min = 0;

            if (guard > 0) 
            {
                max = 0;

                foreach (var guardMin in check[guard])
                {
                    if (guardMin.Value > max) {
                        min = guardMin.Key;
                        max = guardMin.Value;
                    }
                }
            }

            Console.WriteLine("res " + guard + " " + min);

            return guard * min;
        }

        public int Part2(string[] lines)
        {
            Dictionary<int, Dictionary<int, int>> check = ComputeCheck(lines);

            // compute guard sums
            int guard = 0;
            int max = 0;
            int min = 0;

            foreach (var item in check)
            {
                int sum = 0;

                foreach (var guardMin in item.Value)
                {
                    if (guardMin.Value > max)
                    {
                        min = guardMin.Key;
                        max = guardMin.Value;
                        guard = item.Key;
                    }
                }
            }

            Console.WriteLine("res " + guard + " " + min);

            return guard * min;
        }

        private Dictionary<int, Dictionary<int, int>> ComputeCheck(string[] lines)
        {
            SortedDictionary<DateTime, Action> actions = new SortedDictionary<DateTime, Action>();

            foreach (string line in lines)
            {
                Action action = new Action(line);

                actions.Add(action.date, action);
            }

            Dictionary<int, Dictionary<int, int>> check = new Dictionary<int, Dictionary<int, int>>();

            int guard = 0;
            DateTime sleepTime = new DateTime();

            foreach (var item in actions)
            {
                Action action = item.Value;

                Console.WriteLine("date " + item.Key + " => " + item.Value);

                if (action.action == "guard")
                {
                    if (!check.ContainsKey(action.guard))
                    {
                        // init guard
                        Dictionary<int, int> guardCheck = new Dictionary<int, int>();

                        for (int i = 0; i < 60; i++)
                        {
                            guardCheck[i] = 0;
                        }

                        check[action.guard] = guardCheck;
                    }

                    guard = action.guard;
                }

                if (action.action == "sleep")
                {
                    sleepTime = action.date;
                }

                if (action.action == "awake")
                {
                    Dictionary<int, int> guardCheck = check[guard];

                    for (int i = sleepTime.Minute; i < action.date.Minute; i++)
                    {
                        guardCheck[i]++;
                    }
                }
            }

            return check;
        }


        public class Action
        {
            public DateTime date;
            public string action;
            public int guard;

            public Action(string line)
            {
                string dateString = line.Substring(1, line.IndexOf(']') - 1);
                string actionString = line.Substring(line.IndexOf(']') + 2);

                this.date = DateTime.Parse(dateString);

                if (actionString.StartsWith("Guard"))
                {
                    this.action = "guard";
                    this.guard = int.Parse(actionString.Substring(7, actionString.IndexOf(' ', 7) - 7));
                }
                else if (actionString.StartsWith("falls"))
                {
                    this.action = "sleep";
                }
                else if (actionString.StartsWith("wake"))
                {
                    this.action = "awake";
                }
            }

            public override string ToString()
            {
                return this.action + " " + this.guard;
            }
        }
    }
}
