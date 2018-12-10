using System;
using System.Collections.Generic;

namespace AoC2018.Lib
{
    public class Day10
    {
        public int Part1(string[] lines, int seconds)
        {
            List<Point> points = this.Parse(lines);

            for (int i = 0; i < seconds; i++)
            {
                Simulate(points, i);
            }

            return 0;
        }

        private void Simulate(List<Point> points, int second)
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

            //Console.WriteLine("BOUNDS " + second + " -> " + Math.Abs(maxX - minX) + " (" + minX + " " + maxX + ") " + Math.Abs(maxY - minY) + " (" + minY + " " + maxY + ")");

            if (Math.Abs(maxX - minX) < 100 && Math.Abs(maxY - minY) < 100)
            {
                for (int i = minY; i <= maxY; i++)
                {
                    for (int j = minX; j <= maxX; j++)
                    {
                        if (moved.Contains(new Tuple<int, int>(j, i)))
                        {
                            Console.Write("# ");
                        }
                        else
                        {
                            Console.Write(". ");
                        }

                    }

                    Console.WriteLine();
                }
            }
        }

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

        public class Point
        {
            int startX;
            int startY;

            int velocityX;
            int velocityY;

            public Point(int x, int y, int vx, int vy)
            {
                this.startX = x;
                this.startY = y;
                this.velocityX = vx;
                this.velocityY = vy;
            }

            public Tuple<int, int> Move(int second)
            {
                return new Tuple<int, int>(startX + velocityX * second, startY + velocityY * second);
            }
        }
    }
}
