﻿// <copyright file="Day10.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Lib
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Day10 solution class.
    /// </summary>
    public class Day10
    {
        /// <summary>
        /// Solution of part 1.
        /// </summary>
        /// <returns>The part1.</returns>
        /// <param name="lines">Input lines.</param>
        public string Part1(string[] lines)
        {
            List<Point> points = this.Parse(lines);

            int second = this.Simulate(points);

            string[] res = this.Output(points, second);

            return string.Join("\n", res);
        }

        /// <summary>
        /// Solution of part 1.
        /// </summary>
        /// <returns>The part1.</returns>
        /// <param name="lines">Input lines.</param>
        public int Part2(string[] lines)
        {
            List<Point> points = this.Parse(lines);

            int second = this.Simulate(points);

            return second;
        }

        /// <summary>
        /// Simulate the specified points and second.
        /// </summary>
        /// <returns>Soconds of simulation end.</returns>
        /// <param name="points">Points to move.</param>
        private int Simulate(List<Point> points)
        {
            int width = int.MaxValue;
            int height = int.MaxValue;

            bool stop = false;

            int second = 0;

            do
            {
                second++;

                HashSet<Tuple<int, int>> moved = new HashSet<Tuple<int, int>>();

                int minX = int.MaxValue;
                int maxX = int.MinValue;

                int minY = int.MaxValue;
                int maxY = int.MinValue;

                foreach (Point p in points)
                {
                    Tuple<int, int> t = p.Move(second);

                    if (minX > t.Item1)
                    {
                        minX = t.Item1;
                    }

                    if (minY > t.Item2)
                    {
                        minY = t.Item2;
                    }

                    if (maxX < t.Item1)
                    {
                        maxX = t.Item1;
                    }

                    if (maxY < t.Item2)
                    {
                        maxY = t.Item2;
                    }

                    moved.Add(t);
                }

                if (width <= Math.Abs(maxX - minX) && height <= Math.Abs(maxY  - minY))
                {
                    stop = true;
                }

                width = Math.Abs(maxX - minX);
                height = Math.Abs(maxY - minY);
            }
            while (!stop);

            return second - 1;
        }

        /// <summary>
        /// Output the specified points and second.
        /// </summary>
        /// <returns>The output.</returns>
        /// <param name="points">Point list.</param>
        /// <param name="second">Second to display.</param>
        private string[] Output(List<Point> points, int second)
        {
            HashSet<Tuple<int, int>> moved = new HashSet<Tuple<int, int>>();

            int minX = int.MaxValue;
            int maxX = int.MinValue;

            int minY = int.MaxValue;
            int maxY = int.MinValue;

            foreach (Point p in points)
            {
                Tuple<int, int> t = p.Move(second);

                if (minX > t.Item1)
                {
                    minX = t.Item1;
                }

                if (minY > t.Item2)
                {
                    minY = t.Item2;
                }

                if (maxX < t.Item1)
                {
                    maxX = t.Item1;
                }

                if (maxY < t.Item2)
                {
                    maxY = t.Item2;
                }

                moved.Add(t);
            }

            string[] lines = new string[maxY - minY + 1];

            for (int i = minY; i <= maxY; i++)
            {
                for (int j = minX; j <= maxX; j++)
                {
                    if (moved.Contains(new Tuple<int, int>(j, i)))
                    {
                        lines[i - minY] += "#";
                    }
                    else
                    {
                        lines[i - minY] += ".";
                    }
                }
            }

            return lines;
        }

        /// <summary>
        /// Parse the specified lines.
        /// </summary>
        /// <returns>List of points with velocity.</returns>
        /// <param name="lines">Input lines.</param>
        private List<Point> Parse(string[] lines)
        {
            List<Point> res = new List<Point>();

            foreach (string line in lines)
            {
                int index = line.IndexOf(',', 9);

                int x = int.Parse(line.Substring(10, index - 10));

                int index2 = line.IndexOf('>', index);
                int y = int.Parse(line.Substring(index + 1, index2 - index - 1));

                index = index2 + 11;
                index2 = line.IndexOf(',', index);
                int vx = int.Parse(line.Substring(index + 1, index2 - index - 1));

                index = index2;
                index2 = line.IndexOf('>', index);
                int vy = int.Parse(line.Substring(index + 1, index2 - index - 1));

                Point p = new Point(x, y, vx, vy);

                res.Add(p);
            }

            return res;
        }

        /// <summary>
        /// Point class.
        /// </summary>
        public class Point
        {
            /// <summary>
            /// The start x.
            /// </summary>
            private int startX;

            /// <summary>
            /// The start y.
            /// </summary>
            private int startY;

            /// <summary>
            /// The velocity x.
            /// </summary>
            private int velocityX;

            /// <summary>
            /// The velocity y.
            /// </summary>
            private int velocityY;

            /// <summary>
            /// Initializes a new instance of the <see cref="T:AoC2018.Lib.Day10.Point"/> class.
            /// </summary>
            /// <param name="x">The x coordinate.</param>
            /// <param name="y">The y coordinate.</param>
            /// <param name="vx">The x velocity.</param>
            /// <param name="vy">The y velocity.</param>
            public Point(int x, int y, int vx, int vy)
            {
                this.startX = x;
                this.startY = y;

                this.velocityX = vx;
                this.velocityY = vy;
            }

            /// <summary>
            /// Move the point by specified seconds.
            /// </summary>
            /// <returns>Coordinates of target point.</returns>
            /// <param name="second">Seconds to fly.</param>
            public Tuple<int, int> Move(int second)
            {
                return new Tuple<int, int>(this.startX + (this.velocityX * second), this.startY + (this.velocityY * second));
            }
        }
    }
}
