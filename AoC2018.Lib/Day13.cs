// <copyright file="Day13.cs">
//     GPL v3
// </copyright>
// <author>Sven Schoradt</author>

namespace AoC2018.Lib
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Day13 solution class.
    /// </summary>
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

            Tuple<int, int> crash = null;

            do
            {
                crash = g.SimulateToCrash();
            } 
            while (crash == null);

            return crash;
        }

        /// <summary>
        /// Part 1 ogf the solution
        /// </summary>
        /// <returns>Coordinates of the first crash.</returns>
        /// <param name="lines">Input lines.</param>
        public Tuple<int, int> Part2(string[] lines)
        {
            Game g = new Game(lines);

            Tuple<int, int> pos = null;

            do
            {
                pos = g.SimulateToLast();
            }
            while (pos == null);

            return pos;
        }

        /// <summary>
        /// Game implementation class.
        /// </summary>
        public class Game
        {
            /// <summary>
            /// The raster.
            /// </summary>
            private char[,] raster;

            /// <summary>
            /// The width.
            /// </summary>
            private int width;

            /// <summary>
            /// The height.
            /// </summary>
            private int height;

            /// <summary>
            /// The cars of the game.
            /// </summary>
            private List<Car> cars = new List<Car>();

            /// <summary>
            /// Initializes a new instance of the <see cref="T:AoC2018.Lib.Day13.Game"/> class.
            /// </summary>
            /// <param name="lines">Input lines.</param>
            public Game(string[] lines)
            {
                this.height = lines.Length;
                this.width = lines[0].Length;

                this.raster = new char[this.width, this.height];

                for (int i = 0; i < this.width; i++)
                {
                    for (int j = 0; j < this.height; j++)
                    {
                        this.raster[i, j] = lines[j][i];

                        Car c;

                        switch (lines[j][i])
                        {
                            case '<':
                                c = new Car(i, j, 0);

                                this.cars.Add(c);

                                this.raster[i, j] = '-';

                                break;
                            case '>':
                                c = new Car(i, j, 2);

                                this.cars.Add(c);

                                this.raster[i, j] = '-';

                                break;
                            case '^':
                                c = new Car(i, j, 1);

                                this.cars.Add(c);

                                this.raster[i, j] = '|';

                                break;
                            case 'v':
                                c = new Car(i, j, 3);

                                this.cars.Add(c);

                                this.raster[i, j] = '|';

                                break;
                        }
                    }
                }

                this.SortCars();
            }

            /// <summary>
            /// Sorts the cars.
            /// </summary>
            public void SortCars()
            {
                this.cars.Sort(this.CompareCars);
            }

            /// <summary>
            /// Simulates to crash.
            /// </summary>
            /// <returns>The coordinates of the first crash.</returns>
            public Tuple<int, int> SimulateToCrash()
            {
                foreach (Car c in this.cars)
                {
                    c.Move(this.raster);

                    foreach (Car c2 in this.cars)
                    {
                        if (c != c2 && c.Pos(c2.X, c2.Y))
                        {
                            return new Tuple<int, int>(c.X, c.Y);
                        }
                    }
                }

                this.SortCars();

                return null;
            }

            /// <summary>
            /// Simulates to last.
            /// </summary>
            /// <returns>The coordinates of the last car.</returns>
            public Tuple<int, int> SimulateToLast()
            {
                List<Car> work = new List<Car>(this.cars);

                foreach (Car c in work)
                {
                    c.Move(this.raster);

                    foreach (Car c2 in work)
                    {
                        if (c != c2 && c.Pos(c2.X, c2.Y))
                        {
                            this.cars.Remove(c);
                            this.cars.Remove(c2);
                        }
                    }
                }

                if (this.cars.Count == 1)
                {
                    Car last = this.cars[0];

                    return new Tuple<int, int>(last.X, last.Y);
                }

                if (this.cars.Count == 0)
                {
                    return new Tuple<int, int>(-1, -1);
                }

                this.SortCars();

                return null;
            }

            /// <summary>
            /// Debug this instance.
            /// </summary>
            public void Debug()
            {
                for (int i = 0; i < this.height; i++)
                {
                    for (int j = 0; j < this.width; j++)
                    {
                        bool car = false;
                        foreach (Car c in this.cars)
                        {
                            if (c.Pos(j, i))
                            {
                                Console.Write(c.DirectionChar());
                                car = true;
                            }
                        }

                        if (!car)
                        {
                            Console.Write(this.raster[j, i]);
                        }
                    }

                    Console.WriteLine();
                }

                foreach (Car c in this.cars)
                {
                    Console.Write("(" + c.X + "," + c.Y + ")");
                }

                Console.WriteLine();
            }

            /// <summary>
            /// Compares the cars.
            /// </summary>
            /// <returns>The compare result.</returns>
            /// <param name="x">Car one.</param>
            /// <param name="y">Car two.</param>
            private int CompareCars(Car x, Car y)
            {
                if (x.X < y.X)
                {
                    return -1;
                }

                if (x.X > y.X)
                {
                    return 1;
                }

                if (x.Y < y.Y)
                {
                    return -1;
                }

                if (x.Y > y.Y)
                {
                    return 1;
                }

                return 0;
            }

            /// <summary>
            /// The Car.
            /// </summary>
            public class Car
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
                /// The direction.
                /// </summary>
                private int direction;

                /// <summary>
                /// The switches.
                /// </summary>
                private int switches = 0;

                /// <summary>
                /// Initializes a new instance of the <see cref="T:AoC2018.Lib.Day13.Game.Car"/> class.
                /// </summary>
                /// <param name="x">The x coordinate.</param>
                /// <param name="y">The y coordinate.</param>
                /// <param name="direction">The direction.</param>
                public Car(int x, int y, int direction)
                {
                    this.X = x;
                    this.Y = y;

                    this.direction = direction;
                }

                /// <summary>
                /// Gets or sets the y.
                /// </summary>
                /// <value>The y.</value>
                public int Y { get => this.y; set => this.y = value; }

                /// <summary>
                /// Gets or sets the x.
                /// </summary>
                /// <value>The x.</value>
                public int X { get => this.x; set => this.x = value; }

                /// <summary>
                /// Check Position the specified x and y.
                /// </summary>
                /// <returns>True if matched.</returns>
                /// <param name="x">The x coordinate.</param>
                /// <param name="y">The y coordinate.</param>
                public bool Pos(int x, int y)
                {
                    return this.X == x && this.Y == y;
                }

                /// <summary>
                /// Directions the char.
                /// </summary>
                /// <returns>The char.</returns>
                public char DirectionChar()
                {
                    switch (this.direction)
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

                /// <summary>
                /// Move the specified raster.
                /// </summary>
                /// <param name="raster">Raster of game board.</param>
                public void Move(char[,] raster)
                {
                    switch (this.direction)
                    {
                        case 0:
                            this.X--;

                            switch (this.raster[this.X, this.Y])
                            {
                                case '/':
                                    this.direction = 3;
                                    break;
                                case '\\':
                                    this.direction = 1;
                                    break;
                            }

                            break;
                        case 1:
                            this.Y--;

                            switch (raster[this.X, this.Y])
                            {
                                case '/':
                                    this.direction = 2;
                                    break;
                                case '\\':
                                    this.direction = 0;
                                    break;
                            }

                            break;
                        case 2:
                            this.X++;

                            switch (raster[this.X, this.Y])
                            {
                                case '/':
                                    this.direction = 1;
                                    break;
                                case '\\':
                                    this.direction = 3;
                                    break;
                            }

                            break;
                        case 3:
                            this.Y++;

                            switch (raster[this.X, this.Y])
                            {
                                case '/':
                                    this.direction = 0;
                                    break;
                                case '\\':
                                    this.direction = 2;
                                    break;
                            }

                            break;
                    }

                    if (raster[this.X, this.Y] == '+')
                    {
                        switch (this.switches % 3)
                        {
                            case 0:
                                this.direction = this.Mod(this.direction - 1, 4);
                                break;
                            case 1:
                                break;
                            case 2:
                                this.direction = this.Mod(this.direction + 1, 4);
                                break;
                        }

                        this.switches++;
                    }
                }

                /// <summary>
                /// Mod the specified x and m.
                /// </summary>
                /// <returns>The mod.</returns>
                /// <param name="n">Number value.</param>
                /// <param name="m">Modulo value</param>
                private int Mod(int n, int m)
                {
                    return ((n % m) + m) % m;
                }
            }
        }
    }
}
