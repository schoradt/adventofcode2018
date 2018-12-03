// <copyright file="Day03.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Lib
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The solution for the day 2 of the advent of code 2018.
    /// </summary>
    public class Day03
    {
        /// <summary>
        /// Compute the number of fields that are spanned from multiple claims.
        /// </summary>
        /// <returns>Number of multiple used fields.</returns>
        /// <param name="claims">List of claims.</param>
        public int Part1(List<Claim> claims)
        {
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

        /// <summary>
        /// Compute the claim that is not spaned by any other claim.
        /// </summary>
        /// <returns>The claim number.</returns>
        /// <param name="claims">List of claims.</param>
        public int Part2(List<Claim> claims)
        {
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

                if (overlaps.Count == 0)
                {
                    return c1.Number;
                }
            }

            return -1;
        }

        /// <summary>
        /// Parses the claims.
        /// </summary>
        /// <returns>The claims.</returns>
        /// <param name="lines">Claim description lines.</param>
        public List<Claim> ParseClaims(string[] lines)
        {
            List<Claim> claims = new List<Claim>();

            foreach (string line in lines)
            {
                Claim claim = new Claim(line);

                claims.Add(claim);
            }

            return claims;
        }

        /// <summary>
        /// Claim class.
        /// </summary>
        public class Claim
        {
            /// <summary>
            /// Claim number.
            /// </summary>
            private readonly int number;

            /// <summary>
            /// Claim left edge x.
            /// </summary>
            private readonly int edgeX;

            /// <summary>
            /// Claim left edge y.
            /// </summary>
            private readonly int edgeY;

            /// <summary>
            /// Claim width.
            /// </summary>
            private readonly int width;

            /// <summary>
            /// Claim heigth.
            /// </summary>
            private readonly int height;

            /// <summary>
            /// Initializes a new instance of the <see cref="T:AoC2018.Lib.Day03.Claim"/> class.
            /// </summary>
            /// <param name="line">Claim description string.</param>
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

            /// <summary>
            /// Gets the number.
            /// </summary>
            /// <value>The number.</value>
            public int Number
            {
                get => this.number;
            }

            /// <summary>
            /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:AoC2018.Lib.Day03.Claim"/>.
            /// </summary>
            /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:AoC2018.Lib.Day03.Claim"/>.</returns>
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("#");
                sb.Append(this.number);
                sb.Append(" @ ");
                sb.Append(this.edgeX);
                sb.Append(",");
                sb.Append(this.edgeY);
                sb.Append(": ");
                sb.Append(this.width);
                sb.Append("x");
                sb.Append(this.height);

                return sb.ToString();
            }

            /// <summary>
            /// Test if the position is inside the claim.
            /// </summary>
            /// <returns><c>true</c>, if x,y is in claim, <c>false</c> otherwise.</returns>
            /// <param name="x">The x coordinate.</param>
            /// <param name="y">The y coordinate.</param>
            public bool IsIn(int x, int y)
            {
                return (x >= this.edgeX && x < this.edgeX + this.width) && (y >= this.edgeY && y < this.edgeY + this.height);
            }

            /// <summary>
            /// Overlap the specified c.
            /// </summary>
            /// <returns>The overlaping coordinates.</returns>
            /// <param name="c">The claim to  compare</param>
            public HashSet<Tuple<int, int>> Overlap(Claim c)
            {
                HashSet<Tuple<int, int>> overlaps = new HashSet<Tuple<int, int>>();

                for (int i = this.edgeX; i < this.edgeX + this.width; i++)
                {
                    for (int j = this.edgeY; j < this.edgeY + this.height; j++)
                    {
                        if (c.IsIn(i, j))
                        {
                            overlaps.Add(new Tuple<int, int>(i, j));
                        }
                    }
                }

                return overlaps;
            }
        }
    }
}
