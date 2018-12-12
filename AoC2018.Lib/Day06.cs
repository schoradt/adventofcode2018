// <copyright file="Day06.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Lib
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Day 6 sollution class.
    /// </summary>
    public class Day06
    {
        /// <summary>
        /// Part1 of the exercise.
        /// </summary>
        /// <returns>Size of the non infinit area.</returns>
        /// <param name="lines">Puzzle input.</param>
        public int Part1(string[] lines)
        {
            List<Point> points = new List<Point>();

            int i = 1;

            foreach (string line in lines)
            {
                Point point = new Point(i++, int.Parse(line.Substring(0, line.IndexOf(','))), int.Parse(line.Substring(line.IndexOf(',') + 1)));

                points.Add(point);
            }

            int max = 0;
            int minX = int.MaxValue;
            int minY = int.MaxValue;
            int maxX = 0;
            int maxY = 0;

            foreach (var p1 in points)
            {
                if (p1.X > maxX)
                {
                    maxX = p1.X;
                }

                if (p1.X < minX)
                {
                    minX = p1.X;
                }

                if (p1.Y > maxY)
                {
                    maxY = p1.Y;
                }

                if (p1.Y < minY)
                {
                    minY = p1.Y;
                }

                foreach (var p2 in points)
                {
                    int dis = p1.Distance(p2);

                    if (dis > max)
                    {
                        max = dis;
                    }
                }
            }

            minX--;
            minY--;
            maxX++;
            maxY++;

            Point[,] matrix = new Point[maxX - minX + 1, maxY - minY + 1];

            for (i = 0; i <= maxX - minX; i++)
            {
                for (int j = 0; j <= maxY - minY; j++)
                {
                    matrix[i, j] = new Point(0, minX + i, minY + j);

                    int id = 0;
                    int min = int.MaxValue;

                    foreach (var point in points)
                    {
                        int dis = matrix[i, j].Distance(point);

                        if (dis < min)
                        {
                            min = dis;
                            id = point.Id;
                        } 
                        else if (dis == min)
                        {
                            id = 0;
                        }
                    }

                    matrix[i, j].Id = id;
                }
            }

            int maxArea = 0;

            foreach (var point in points)
            {
                bool inf = false;
                int count = 0;

                for (int j = 0; j <= maxY - minY; j++)
                {
                    for (i = 0; i <= maxX - minX; i++)
                    {
                        if (matrix[i, j].Id == point.Id)
                        {
                            count++;

                            if (i == 0 || i == maxX - minX || j == 0 || j == maxY - minY)
                            {
                                inf = true;
                            }
                        }
                    }
                }

                if (!inf && count > maxArea)
                {
                    maxArea = count;
                }
            }

            return maxArea;
        }

        /// <summary>
        /// Part 2 of the puzzle.
        /// </summary>
        /// <returns>What is the size of the region containing all locations which have a total distance to all given coordinates of less than 10000?</returns>
        /// <param name="lines">Puzzle input.</param>
        /// <param name="maxDistance">Max distance.</param>
        public int Part2(string[] lines, int maxDistance)
        {
            List<Point> points = new List<Point>();

            int i = 1;

            foreach (string line in lines)
            {
                Point point = new Point(i++, int.Parse(line.Substring(0, line.IndexOf(','))), int.Parse(line.Substring(line.IndexOf(',') + 1)));

                points.Add(point);
            }

            int max = 0;
            int minX = int.MaxValue;
            int minY = int.MaxValue;
            int maxX = 0;
            int maxY = 0;

            foreach (var p1 in points)
            {
                if (p1.X > maxX)
                {
                    maxX = p1.X;
                }

                if (p1.X < minX)
                {
                    minX = p1.X;
                }

                if (p1.Y > maxY)
                {
                    maxY = p1.Y;
                }

                if (p1.Y < minY)
                {
                    minY = p1.Y;
                }

                foreach (var p2 in points)
                {
                    int dis = p1.Distance(p2);

                    if (dis > max)
                    {
                        max = dis;
                    }
                }
            }

            minX--;
            minY--;
            maxX++;
            maxY++;

            Point[,] matrix = new Point[maxX - minX + 1, maxY - minY + 1];

            for (i = 0; i <= maxX - minX; i++)
            {
                for (int j = 0; j <= maxY - minY; j++)
                {
                    matrix[i, j] = new Point(0, minX + i, minY + j);

                    int distance = 0;

                    foreach (var point in points)
                    {
                        distance += matrix[i, j].Distance(point);

                        matrix[i, j].Total = distance;
                    }
                }
            }

            int count = 0;

            for (int j = 0; j <= maxY - minY; j++)
            {
                for (i = 0; i <= maxX - minX; i++)
                {
                    if (matrix[i, j].Total < maxDistance)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Point class.
        /// </summary>
        public class Point
        {
            /// <summary>
            /// The x.
            /// </summary>
            private int x;

            /// <summary>
            /// The y.
            /// </summary>
            private int y;

            /// <summary>
            /// The identifier.
            /// </summary>
            private int id;

            /// <summary>
            /// The total area around this point.
            /// </summary>
            private int total;

            /// <summary>
            /// Initializes a new instance of the <see cref="T:AoC2018.Lib.Day06.Point"/> class.
            /// </summary>
            /// <param name="id">Identifier of the point.</param>
            /// <param name="x">The x coordinate.</param>
            /// <param name="y">The y coordinate.</param>
            public Point(int id, int x, int y)
            {
                this.id = id;
                this.x = x;
                this.y = y;
            }

            /// <summary>
            /// Gets the x.
            /// </summary>
            /// <value>The x.</value>
            public int X { get => this.x; internal set => this.x = value; }

            /// <summary>
            /// Gets the y.
            /// </summary>
            /// <value>The y.</value>
            public int Y { get => this.y; internal set => this.y = value; }

            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>The identifier.</value>
            public int Id { get => this.id; set => this.id = value; }

            /// <summary>
            /// Gets or sets the total.
            /// </summary>
            /// <value>The total.</value>
            public int Total { get => this.total; set => this.total = value; }

            /// <summary>
            /// Distance to the given point.
            /// </summary>
            /// <returns>The distance.</returns>
            /// <param name="point">Other point.</param>
            public int Distance(Point point)
            {
                return Math.Abs(this.x - point.x) + Math.Abs(this.y - point.y);
            }
        }
    }
}
