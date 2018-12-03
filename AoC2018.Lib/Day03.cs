
namespace AoC2018.Lib
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Day03
    {
        public int Part1(string[] lines)
        {
            List<Claim> claims = new List<Claim>();

            foreach (string line in lines)
            {
                Claim claim = new Claim(line);

                claims.Add(claim);
            }

            HashSet<Tuple<int, int>> overlaps = new HashSet<Tuple<int, int>>();

            List<Claim> claims2 = new List<Claim>(claims);

            foreach (Claim c1 in claims)
            {
                claims2.Remove(c1);

                foreach (Claim c2 in claims2)
                {
                    HashSet<Tuple<int, int>> overlap = c1.Overlap(c2);

                    overlaps.UnionWith(overlap);
                }
            }

            return overlaps.Count;
        }

        public int Part2(string[] lines)
        {
            List<Claim> claims = new List<Claim>();

            foreach (string line in lines)
            {
                Claim claim = new Claim(line);

                claims.Add(claim);
            }

            foreach (Claim c1 in claims)
            {
                List<Claim> claims2 = new List<Claim>(claims);

                claims2.Remove(c1);

                HashSet<Tuple<int, int>> overlaps = new HashSet<Tuple<int, int>>();

                foreach (Claim c2 in claims2)
                {
                    HashSet<Tuple<int, int>> overlap = c1.Overlap(c2);

                    overlaps.UnionWith(overlap);
                }

                if (overlaps.Count == 0) {
                    return c1.Number;
                }
            }

            return -1;
        }


        public class Claim
        {
            private readonly int number;

            private readonly int edgeX;
            private readonly int edgeY;

            private readonly int width;
            private readonly int height;

            public Claim(string line)
            {
                int posAt = line.IndexOf('@');

                this.number = int.Parse(line.Substring(1, posAt - 2));

                int posComma = line.IndexOf(',');
                int posColon = line.IndexOf(':');

                this.edgeX = int.Parse(line.Substring(posAt + 1, posComma - posAt - 1));
                this.edgeY = int.Parse(line.Substring(posComma + 1, posColon - posComma - 1));

                int posX = line.IndexOf('x');

                this.width = int.Parse(line.Substring(posColon + 1, posX - posColon - 1));
                this.height = int.Parse(line.Substring(posX + 1));
            }

            public override string ToString() {
                StringBuilder sb = new StringBuilder();

                sb.Append("#");
                sb.Append(this.number);
                sb.Append(" @ ");
                sb.Append(edgeX);
                sb.Append(",");
                sb.Append(edgeY);
                sb.Append(": ");
                sb.Append(width);
                sb.Append("x");
                sb.Append(height);

                return sb.ToString();
            }

            public int Number
            {
                get => number;
            }

            public bool IsIn(int x, int y) {
                return (x >= this.edgeX && x < edgeX + width) && (y >= edgeY && y < edgeY + height);
            }

            public HashSet<Tuple<int, int>> Overlap(Claim c) {
                HashSet<Tuple<int, int>> overlaps = new HashSet<Tuple<int, int>>();

                for (int i = edgeX; i < edgeX + width; i++)
                {
                    for (int j = edgeY; j < edgeY + height; j++)
                    {
                        if (c.IsIn(i, j)) {
                            overlaps.Add(new Tuple<int, int>(i, j));
                        }
                    }
                }

                return overlaps;
            }
        }
    }
}
