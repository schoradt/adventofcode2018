// <copyright file="Day04.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Lib
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Day04 solution class.
    /// </summary>
    public class Day04
    {
        /// <summary>
        /// Process variant one of the guard analysis.
        /// </summary>
        /// <returns>The product of guard number and best minute to escape.</returns>
        /// <param name="lines">Guard sleeping log.</param>
        public int Part1(string[] lines)
        {
            Dictionary<int, Dictionary<int, int>> check = this.ComputeCheck(lines);

            // compute guard sums
            int guard = 0;
            int max = 0;

            foreach (var item in check)
            {
                int sum = 0;

                foreach (var guardMin in item.Value)
                {
                    sum += guardMin.Value;
                }

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
                    if (guardMin.Value > max)
                    {
                        min = guardMin.Key;
                        max = guardMin.Value;
                    }
                }
            }

            return guard * min;
        }

        /// <summary>
        /// Process variant 2 of the guard sleeping analysis.
        /// </summary>
        /// <returns>The product of guard and most sleeped minute.</returns>
        /// <param name="lines">Guard sleeping log.</param>
        public int Part2(string[] lines)
        {
            Dictionary<int, Dictionary<int, int>> check = this.ComputeCheck(lines);

            // compute guard min
            int guard = 0;
            int max = 0;
            int min = 0;

            foreach (var item in check)
            {
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

            return guard * min;
        }

        /// <summary>
        /// Parse the guard sleeping log and create an ordered action list. 
        /// </summary>
        /// <returns>The ordered action list.</returns>
        /// <param name="lines">Guard sleeping log.</param>
        private Dictionary<int, Dictionary<int, int>> ComputeCheck(string[] lines)
        {
            SortedDictionary<DateTime, Action> actions = new SortedDictionary<DateTime, Action>();

            foreach (string line in lines)
            {
                Action action = new Action(line);

                actions.Add(action.Date, action);
            }

            Dictionary<int, Dictionary<int, int>> check = new Dictionary<int, Dictionary<int, int>>();

            int guard = 0;
            DateTime sleepTime = new DateTime();

            foreach (var item in actions)
            {
                Action action = item.Value;

                if (action.Name == "guard")
                {
                    if (!check.ContainsKey(action.Guard))
                    {
                        // init guard
                        Dictionary<int, int> guardCheck = new Dictionary<int, int>();

                        for (int i = 0; i < 60; i++)
                        {
                            guardCheck[i] = 0;
                        }

                        check[action.Guard] = guardCheck;
                    }

                    guard = action.Guard;
                }

                if (action.Name == "sleep")
                {
                    sleepTime = action.Date;
                }

                if (action.Name == "awake")
                {
                    Dictionary<int, int> guardCheck = check[guard];

                    for (int i = sleepTime.Minute; i < action.Date.Minute; i++)
                    {
                        guardCheck[i]++;
                    }
                }
            }

            return check;
        }

        /// <summary>
        /// Action class.
        /// </summary>
        public class Action
        {
            /// <summary>
            /// Date of action.
            /// </summary>
            private DateTime date;

            /// <summary>
            /// Action name.
            /// </summary>
            private string name;

            /// <summary>
            /// Guard number.
            /// </summary>
            private int guard;

            /// <summary>
            /// Initializes a new instance of the <see cref="T:AoC2018.Lib.Day04.Action"/> class.
            /// </summary>
            /// <param name="line">Guard sleeping log line.</param>
            public Action(string line)
            {
                string dateString = line.Substring(1, line.IndexOf(']') - 1);
                string actionString = line.Substring(line.IndexOf(']') + 2);

                this.Date = DateTime.Parse(dateString);

                if (actionString.StartsWith("Guard"))
                {
                    this.Name = "guard";
                    this.Guard = int.Parse(actionString.Substring(7, actionString.IndexOf(' ', 7) - 7));
                }
                else if (actionString.StartsWith("falls"))
                {
                    this.Name = "sleep";
                }
                else if (actionString.StartsWith("wake"))
                {
                    this.Name = "awake";
                }
            }

            /// <summary>
            /// Gets or sets the date.
            /// </summary>
            /// <value>The date.</value>
            public DateTime Date { get => this.date; set => this.date = value; }

            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            public string Name { get => this.name; set => this.name = value; }

            /// <summary>
            /// Gets or sets the guard.
            /// </summary>
            /// <value>The guard.</value>
            public int Guard { get => this.guard; set => this.guard = value; }

            /// <summary>
            /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:AoC2018.Lib.Day04.Action"/>.
            /// </summary>
            /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:AoC2018.Lib.Day04.Action"/>.</returns>
            public override string ToString()
            {
                return this.Name + " " + this.Guard;
            }
        }
    }
}
