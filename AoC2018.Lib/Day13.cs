using System;
using System.Collections.Generic;

namespace AoC2018.Lib
{
    public class Day13
    {
        /// <summary>
        /// Part 1 ogf the solution
        /// </summary>
        /// <returns>Coordinates of the first crash.</returns>
        /// <param name="lines">Input lines.</param>
        public Tuple<int, int> Part1(string[] lines)
        {
            Game g = new Game(lines);

            g.Debug();

            Tuple<int, int> crash = null;

            do
            {
                crash = g.SimulateToCrash();

                //g.Debug();
            } while (crash == null);

            g.Debug();

            return crash;
        }

        /// <summary>
        /// Game implementation class.
        /// </summary>
        public class Game
        {
            char[,] raster;
            int width;
            int height;

            List<Car> cars = new List<Car>();

            /// <summary>
            /// Initializes a new instance of the <see cref="T:AoC2018.Lib.Day13.Game"/> class.
            /// </summary>
            /// <param name="lines">Input lines.</param>
            public Game(string[] lines)
            {
                height = lines.Length;
                width = lines[0].Length;

                raster = new char[width, height];

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        raster[i, j] = lines[j][i];
                        Car c;
                        switch (lines[j][i])
                        {
                            case '<':
                                c = new Car(i, j, 0);

                                cars.Add(c);

                                raster[i, j] = '-';
                                break;
                            case '>':
                                c = new Car(i, j, 2);

                                cars.Add(c);

                                raster[i, j] = '-';
                                break;
                            case '^':
                                c = new Car(i, j, 1);

                                cars.Add(c);

                                raster[i, j] = '|';
                                break;
                            case 'v':
                                c = new Car(i, j, 3);

                                cars.Add(c);

                                raster[i, j] = '|';
                                break;
                        }
                    }
                }
            }

            public Tuple<int, int> SimulateToCrash()
            {
                HashSet<Car> moved = new HashSet<Car>();

                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        foreach (Car c in cars)
                        {
                            if (!moved.Contains(c) && c.Pos(i, j))
                            {
                                c.Move(raster);

                                moved.Add(c);
                            }
                        }

                        foreach (Car c1 in cars)
                        {
                            foreach (Car c2 in cars)
                            {
                                if (c1 != c2 && c1.Pos(c2.X, c2.Y))
                                {
                                    return new Tuple<int, int>(c2.X, c2.Y);
                                }
                            }
                        }
                    }
                }

                return null;
            }

            public void Debug()
            {
                for (int i = 0; i < height; i++)
                {
                    for( int j = 0; j < width; j++)
                    {
                        bool car = false;
                        foreach (Car c in cars)
                        {
                            if (c.Pos(j, i))
                            {
                                Console.Write(c.DirectionChar());
                                car = true;
                            }
                        }

                        if (!car)
                        {
                            Console.Write(raster[j, i]);
                        }
                    }

                    Console.WriteLine();
                }

                System.Threading.Thread.Sleep(1000);
            }

            public class Car
            {
                private int x;
                private int y;

                private int direction;

                private int switches = 0;

                public int Y { get => y; set => y = value; }
                public int X { get => x; set => x = value; }

                public Car(int x, int y, int direction)
                {
                    this.X = x;
                    this.Y = y;

                    this.direction = direction;

                    //Console.WriteLine("create car " + x + " " + y + " " + direction);
                }

                public bool Pos(int x, int y)
                {
                    return (this.X == x && this.Y == y);
                }

                public char DirectionChar()
                {
                    switch(direction)
                    {
                        case 0:
                            return '<';
                        case 1:
                            return '^';
                        case 2:
                            return '>';
                        case 3:
                            return 'v';
                        default:
                            return 'X';
                    }
                }

                public void Move(char[,] raster)
                {
                    //Console.WriteLine("MOVE " + x + " " + y + " " + direction);

                    switch (direction)
                    {
                        case 0:
                            this.X--;

                            switch (raster[X, Y])
                            {
                                case '/':
                                    direction = 3;
                                    break;
                                case '\\':
                                    direction = 1;
                                    break;
                            }
                            break;
                        case 1:
                            this.Y--;

                            switch (raster[X, Y])
                            {
                                case '/':
                                    direction = 2;
                                    break;
                                case '\\':
                                    direction = 0;
                                    break;
                            }
                            break;
                        case 2:
                            this.X++;

                            switch (raster[X, Y])
                            {
                                case '/':
                                    direction = 1;
                                    break;
                                case '\\':
                                    direction = 3;
                                    break;
                            }
                            break;
                        case 3:
                            this.Y++;

                            switch (raster[X, Y])
                            {
                                case '/':
                                    direction = 0;
                                    break;
                                case '\\':
                                    direction = 2;
                                    break;
                            }
                            break;
                    }

                    if (raster[X, Y] == '+')
                    {
                        //Console.WriteLine("SWITCH " + (switches % 3) + " " + direction);

                        switch (switches % 3)
                        {
                            case 0:
                                direction = (direction - 1) % 4;
                                break;
                            case 1:
                                break;
                            case 2:
                                direction = (direction + 1) % 4;
                                break;
                        }

                        //Console.WriteLine("AFTER SWITCH " + (switches % 3) + " " + direction);

                        switches++;
                    }

                    //Console.WriteLine("AFTER " + x + " " + y + " " + direction);

                }
            }
        }
    }
}
