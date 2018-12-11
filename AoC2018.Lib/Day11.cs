using System;
using System.Diagnostics;

namespace AoC2018.Lib
{
    public class Day11
    {
        public string Part1(int gridSerialNumber)
        {
            int[,] raster = CreateRaster(gridSerialNumber);

            Result point = PowerfulSquare(raster, gridSerialNumber, 3);

            return point.X + "," + point.Y;
        }

        public string Part2(int gridSerialNumber)
        {
            int[,] raster = CreateRaster(gridSerialNumber);

            Result point = new Result(0, 0, 0, 0);
            int min = int.MinValue;

            for (int i = 1; i < 299; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                Result p = PowerfulSquare(raster, gridSerialNumber, i);
                Console.WriteLine("Compute size " + i + " (" + sw.ElapsedMilliseconds + " ms)" );

                if (min < p.Power)
                {
                    point = p;
                    min = p.Power;

                    Console.WriteLine("min " + point.X + "," + point.Y + "," + point.Size);
                }
            }

            return point.X + "," + point.Y + "," + point.Size;
        }


        public int[,] CreateRaster(int gridSerialNumber) {
            int[,] raster = new int[300, 300];

            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 300; j++)
                {
                    raster[i, j] = ComutePowerLevel(i, j, gridSerialNumber);
                }
            }

            return raster;
        }

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

        public int ComutePowerLevel(int x, int y, int gridSerialNumber)
        {
            int rackId = x + 10;

            int powerLevel = (rackId * y + gridSerialNumber) * rackId;

            int hundred = 0;

            if (powerLevel >= 100)
            {
                hundred = powerLevel % 1000;
            
                hundred = (hundred - (hundred % 100)) / 100;
            }

            return hundred - 5;
        }

        public class Result
        {
            int x;
            int y;
            int size;
            int power;

            public Result(int x, int y, int size, int power)
            {
                this.x = x;
                this.y = y;
                this.size = size;
                this.power = power;
            }

            public int X { get => x; set => x = value; }
            public int Y { get => y; set => y = value; }
            public int Size { get => size; set => size = value; }
            public int Power { get => power; set => power = value; }

            public override bool Equals(object obj)
            {
                return this.Equals(obj as Result);
            }

            public bool Equals(Result other)
            {
                if (other == null)
                    return false;

                return this.X == other.X && this.Y == other.Y && this.Size == other.Size;
            }

            public override int GetHashCode()
            {
                var hashCode = 986832615;
                hashCode = hashCode * -1521134295 + x.GetHashCode();
                hashCode = hashCode * -1521134295 + y.GetHashCode();
                hashCode = hashCode * -1521134295 + size.GetHashCode();
                return hashCode;
            }
        }
    }
}
