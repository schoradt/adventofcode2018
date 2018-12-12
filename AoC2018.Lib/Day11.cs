// <copyright file="Day11.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Lib
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Day11 solution class.
    /// </summary>
    public class Day11
    {
        /// <summary>
        /// Part1 of the puzzle solution.
        /// </summary>
        /// <returns>The solution.</returns>
        /// <param name="gridSerialNumber">Grid serial number.</param>
        public string Part1(int gridSerialNumber)
        {
            int[,] raster = this.CreateRaster(gridSerialNumber);

            Result point = this.PowerfulSquare(raster, gridSerialNumber, 3);

            return point.X + "," + point.Y;
        }

        /// <summary>
        /// Part 2 of the puzzle solution.
        /// </summary>
        /// <returns>The solution.</returns>
        /// <param name="gridSerialNumber">Grid serial number.</param>
        public string Part2(int gridSerialNumber)
        {
            int[,] raster = this.CreateRaster(gridSerialNumber);

            Result point = new Result(0, 0, 0, 0);
            int min = int.MinValue;

            for (int i = 1; i < 299; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                Result p = this.PowerfulSquare(raster, gridSerialNumber, i);

                Console.WriteLine("Compute size " + i + " (" + sw.ElapsedMilliseconds + " ms)");

                if (min < p.Power)
                {
                    point = p;
                    min = p.Power;

                    Console.WriteLine("min " + point.X + "," + point.Y + "," + point.Size);
                }
            }

            return point.X + "," + point.Y + "," + point.Size;
        }

        /// <summary>
        /// Creates the raster.
        /// </summary>
        /// <returns>The raster.</returns>
        /// <param name="gridSerialNumber">Grid serial number.</param>
        public int[,] CreateRaster(int gridSerialNumber)
        {
            int[,] raster = new int[300, 300];

            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 300; j++)
                {
                    raster[i, j] = this.ComutePowerLevel(i, j, gridSerialNumber);
                }
            }

            return raster;
        }

        /// <summary>
        /// Powerfuls squares.
        /// </summary>
        /// <returns>The square.</returns>
        /// <param name="raster">Raster definition.</param>
        /// <param name="gridSerialNumber">Grid serial number.</param>
        /// <param name="size">Sqare size.</param>
        public Result PowerfulSquare(int[,] raster, int gridSerialNumber, int size)
        {
            int px = 0;
            int py = 0;

            int sum = int.MinValue;

            for (int i = 0; i < 300 - size; i++)
            {
                for (int j = 0; j < 300 - size; j++)
                {
                    int blockSum = 0;

                    for (int k = i; k < i + size; k++)
                    {
                        for (int l = j; l < j + size; l++)
                        {
                            blockSum += raster[k, l];
                        }
                    }

                    if (blockSum > sum)
                    {
                        sum = blockSum;

                        px = i;
                        py = j;
                    }
                }
            }

            return new Result(px, py, size, sum);
        }

        /// <summary>
        /// Comutes the power level.
        /// </summary>
        /// <returns>The power level.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="gridSerialNumber">Grid serial number.</param>
        public int ComutePowerLevel(int x, int y, int gridSerialNumber)
        {
            int rackId = x + 10;

            int powerLevel = ((rackId * y) + gridSerialNumber) * rackId;

            int hundred = 0;

            if (powerLevel >= 100)
            {
                hundred = powerLevel % 1000;
            
                hundred = (hundred - (hundred % 100)) / 100;
            }

            return hundred - 5;
        }

        /// <summary>
        /// Result class.
        /// </summary>
        public class Result
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
            /// The size.
            /// </summary>
            private int size;

            /// <summary>
            /// The power.
            /// </summary>
            private int power;

            /// <summary>
            /// Initializes a new instance of the <see cref="T:AoC2018.Lib.Day11.Result"/> class.
            /// </summary>
            /// <param name="x">The x coordinate.</param>
            /// <param name="y">The y coordinate.</param>
            /// <param name="size">Square size.</param>
            /// <param name="power">Square power.</param>
            public Result(int x, int y, int size, int power)
            {
                this.x = x;
                this.y = y;
                this.size = size;
                this.power = power;
            }

            /// <summary>
            /// Gets or sets the x.
            /// </summary>
            /// <value>The x.</value>
            public int X { get => this.x; set => this.x = value; }

            /// <summary>
            /// Gets or sets the y.
            /// </summary>
            /// <value>The y.</value>
            public int Y { get => this.y; set => this.y = value; }

            /// <summary>
            /// Gets or sets the size.
            /// </summary>
            /// <value>The size.</value>
            public int Size { get => this.size; set => this.size = value; }

            /// <summary>
            /// Gets or sets the power.
            /// </summary>
            /// <value>The power.</value>
            public int Power { get => this.power; set => this.power = value; }

            /// <summary>
            /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="T:AoC2018.Lib.Day11.Result"/>.
            /// </summary>
            /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="T:AoC2018.Lib.Day11.Result"/>.</param>
            /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current
            /// <see cref="T:AoC2018.Lib.Day11.Result"/>; otherwise, <c>false</c>.</returns>
            public override bool Equals(object obj)
            {
                return this.Equals(obj as Result);
            }

            /// <summary>
            /// Determines whether the specified <see cref="AoC2018.Lib.Day11.Result"/> is equal to the current <see cref="T:AoC2018.Lib.Day11.Result"/>.
            /// </summary>
            /// <param name="other">The <see cref="AoC2018.Lib.Day11.Result"/> to compare with the current <see cref="T:AoC2018.Lib.Day11.Result"/>.</param>
            /// <returns><c>true</c> if the specified <see cref="AoC2018.Lib.Day11.Result"/> is equal to the current
            /// <see cref="T:AoC2018.Lib.Day11.Result"/>; otherwise, <c>false</c>.</returns>
            public bool Equals(Result other)
            {
                if (other == null)
                {
                    return false;
                }

                return this.X == other.X && this.Y == other.Y && this.Size == other.Size;
            }

            /// <summary>
            /// Serves as a hash function for a <see cref="T:AoC2018.Lib.Day11.Result"/> object.
            /// </summary>
            /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as
            /// a hash table.</returns>
            public override int GetHashCode()
            {
                var hashCode = 986832615;
                hashCode = (hashCode * -1521134295) + this.x.GetHashCode();
                hashCode = (hashCode * -1521134295) + this.y.GetHashCode();
                hashCode = (hashCode * -1521134295) + this.size.GetHashCode();
                return hashCode;
            }
        }
    }
}
