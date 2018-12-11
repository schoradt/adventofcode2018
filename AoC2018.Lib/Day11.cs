using System;
namespace AoC2018.Lib
{
    public class Day11
    {
        public string Part1(int gridSerialNumber)
        {
            Tuple<int, int> point = PowerfulSquare(gridSerialNumber);

            return point.Item1 + "," + point.Item2;
        }

        public Tuple<int, int> PowerfulSquare(int gridSerialNumber)
        {
            int px = 0;
            int py = 0;

            int[,] raster = new int[300, 300];

            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 300; j++)
                {
                    raster[i, j] = ComutePowerLevel(i, j, gridSerialNumber);
                }
            }

            int sum = int.MinValue;

            for (int i = 0; i < 297; i++)
            {
                for (int j = 0; j < 297; j++)
                {
                    int blockSum = 0;

                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            blockSum += raster[i + k, j + l];
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

            return new Tuple<int, int>(px, py);
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
    }
}
