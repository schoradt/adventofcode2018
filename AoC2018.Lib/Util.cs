using System;
namespace AoC2018.Lib
{
    public static class Util
    {
        /// <summary>
        /// Compares two points.
        /// </summary>
        /// <returns>The compare result.</returns>
        /// <param name="p1">Point one.</param>
        /// <param name="p2">Point two.</param>
        public static int ComparePoints(Point p1, Point p2)
        {
            if (p1.Y < p2.Y)
            {
                return -1;
            }

            if (p1.Y > p2.Y)
            {
                return 1;
            }

            if (p1.X < p2.X)
            {
                return -1;
            }

            if (p1.X > p2.X)
            {
                return 1;
            }

            return 0;
        }

    }

    public class Point : IComparable<Point>
    {
        private long x;
        private long y;

        public Point(long x, long y)
        {
            this.X = x;
            this.Y = y;
        }

        public long X { get => this.x; set => this.x = value; }
        public long Y { get => this.y; set => this.y = value; }

        public int CompareTo(Point other)
        {
            return Util.ComparePoints(this, other);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.X, this.Y);
        }
    }
}
