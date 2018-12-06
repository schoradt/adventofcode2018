using System;
using System.Collections.Generic;

namespace AoC2018.Lib
{
    public class Day06
    {
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

                    foreach(var point in points)
                    {
                        int dis = matrix[i, j].Distance(point);

                        if (dis < min)
                        {
                            min = dis;
                            id = point.Id;
                        } else if (dis == min)
                        {
                            id = 0;
                        }
                    }

                    matrix[i, j].Id = id;
                }
            }

            int maxArea = 0;

            foreach(var point in points)
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

        class Point
        {
            int x;
            int y;

            int id;
            int total;

            public Point(int id, int x, int y)
            {
                this.id = id;
                this.x = x;
                this.y = y;
            }

            public int X { get => this.x; internal set => this.x = value; }
            public int Y { get => this.y; internal set => this.y = value; }
            public int Id { get => this.id; set => this.id = value; }
            public int Total { get => this.total; set => this.total = value; }

            public int Distance(Point p)
            {
                return Math.Abs(this.x - p.x) + Math.Abs(this.y - p.y);
            }
        }
    }
}
