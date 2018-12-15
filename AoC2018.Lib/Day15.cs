using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Linq;
namespace AoC2018.Lib
{
    public class Day15
    {
        public int Part1(string[] lines)
        {
            Game g = new Game(lines);

            g.Debug();

            int round = 0;

            do
            {
                bool full = g.Round();

                if (full)
                {
                    round++;
                }

                Console.WriteLine("Round " + round);

                g.Debug();


            }
            while (g.CheckTargets());

            int res = g.HitSum() *  round;

            return res;
        }

        public class Game
        {
            RasterElement[,] raster;

            List<Combat> elves = new List<Combat>();
            List<Combat> goblins = new List<Combat>();

            List<Combat> combats = new List<Combat>();

            public Game(string[] lines)
            {
                int height = lines.Length;
                int width = lines[0].Length;

                this.raster = new RasterElement[width, height];

                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        bool wall = false;
                        Combat combat = null;

                        char c = lines[j][i];
                        switch (c)
                        {
                            case '#':
                                wall = true;
                                break;
                            case 'E':
                                combat = new Combat(i, j, 1);

                                elves.Add(combat);
                                break;
                            case 'G':
                                combat = new Combat(i, j, 2);

                                goblins.Add(combat);
                                break;
                        }

                        raster[i, j] = new RasterElement(i, j, wall, combat);
                    }
                }

                combats.AddRange(elves);
                combats.AddRange(goblins);
            }

            public bool Round()
            {
                combats.Sort(Util.ComparePoints);

                List<Combat> work = new List<Combat>(combats);
                work.Sort(Util.ComparePoints);

                foreach (Combat c in work)
                {
                    if (!this.CheckTargets())
                    {
                        return false;
                    }

                    c.Debug();

                    this.Move(c);

                    this.Attack(c);
                }

                return true;
            }

            public bool CheckTargets()
            {
                bool elvesAvailable = false;
                bool goblinsAvailable = false;

                foreach (Combat c in combats)
                {
                    elvesAvailable |= c.Type == 1;
                    goblinsAvailable |= c.Type == 2;
                }

                return elvesAvailable && goblinsAvailable;
            }

            public int HitSum()
            {
                int sum = 0;

                foreach (Combat c in combats)
                {
                    sum += c.HitPoints;
                }

                return sum;
            }

            private void Attack(Combat c)
            {
                if (c.HitPoints < 0)
                {
                    return;
                }

                int type = 1;

                if (c.Type == 1)
                {
                    type = 2;
                }

                List<Combat> enemies = GetEnemies(c, type);

                enemies.Sort(this.CompareEnemies);

                if (!enemies.Any())
                {
                    return;
                }

                Combat target = enemies.First();

                target.HitPoints -= 3;

                if (target.HitPoints < 0)
                {
                    Console.Write("KILL ");
                    target.Debug();

                    raster[target.X, target.Y].Combat = null;

                    combats.Remove(target);
                }
            }

            private int CompareEnemies(Combat x, Combat y)
            {
                int hitCompare = x.HitPoints.CompareTo(y.HitPoints);

                if (hitCompare != 0)
                {
                    return hitCompare;
                }

                return Util.ComparePoints(x, y);
            }

            private List<Combat> GetEnemies(Point point, int type)
            {
                List<Point> candidates = new List<Point>
                {
                    new Point(point.X + 1, point.Y),
                    new Point(point.X - 1, point.Y),
                    new Point(point.X, point.Y + 1),
                    new Point(point.X, point.Y - 1)
                };

                List<Combat> enemies = new List<Combat>();
                 
                foreach (Point check in candidates)
                {
                    if (raster[check.X, check.Y].Combat != null && raster[check.X, check.Y].Combat.Type == type)
                    {
                        enemies.Add(raster[check.X, check.Y].Combat);
                    }
                }

                return enemies;
            }

            private void Move(Combat c)
            {
                if (c.HitPoints < 0)
                {
                    return;
                }

                int type = 1;

                if (c.Type == 1)
                {
                    type = 2;
                }

                if (NextToEnemy(c, type)) {
                    return;
                }

                List<List<Point>> paths = ShortestPathToEnemy(c);

                //foreach (List<Point> path in paths)
                //{
                //    foreach (Point p in path)
                //    {
                //        Console.Write(p.ToString() + " ");
                //    }

                //    Console.WriteLine();
                //}

                //Console.WriteLine();
                //Console.WriteLine();

                if (paths.Count == 0)
                {
                    // no possible move
                    return;
                }

                paths.Sort((x, y) => Util.ComparePoints(x.Last(), y.Last()));

                Point step = paths.First()[1];

                raster[c.X, c.Y].Combat = null;

                raster[step.X, step.Y].Combat = c;

                c.X = step.X;
                c.Y = step.Y;
            }

            private List<List<Point>> ShortestPathToEnemy(Combat c)
            {
                int type = 1;

                if (c.Type == 1)
                {
                    type = 2;
                }

                List<List<Point>> paths = new List<List<Point>>();

                List<Point> basePath = new List<Point>
                {
                    new Point(c.X, c.Y)
                };

                paths.Add(basePath);

                bool found = false;

                do
                {
                    Console.WriteLine("path " + paths.First().Count());

                    List<List<Point>> old = new List<List<Point>>(paths);

                    paths.Clear();

                    foreach (List<Point> path in old)
                    {
                        //Console.Write("path ");

                        //foreach (Point p in path)
                        //{
                        //    Console.Write(p.ToString() + " ");
                        //}

                        //Console.WriteLine();

                        Point last = path.Last();

                        List<Point> candidates = new List<Point>
                        {
                            new Point(last.X + 1, last.Y),
                            new Point(last.X - 1, last.Y),
                            new Point(last.X, last.Y + 1),
                            new Point(last.X, last.Y - 1)
                        };

                        foreach (Point candidate in candidates)
                        {
                            if (raster[candidate.X, candidate.Y].Free() && path.Find((x) => x.X == candidate.X && x.Y == candidate.Y) == null)
                            {
                                //Console.Write("    " + candidate + " ");

                                List<Point> newPath = new List<Point>(path);
                                newPath.Add(candidate);

                                bool enemy = this.NextToEnemy(candidate, type);

                                if (enemy && !found)
                                {
                                    found = true;

                                    paths.Clear();

                                    paths.Add(newPath);

                                    //Console.WriteLine("=> Add1 " + enemy + " " + found);
                                }
                                else if ((enemy && found) || !found)
                                {
                                    //Console.WriteLine("=> Add2 " + enemy + " " + found);
                                    paths.Add(newPath);
                                }
                                else
                                {
                                    //Console.WriteLine("=> Ignore " + enemy + " " + found);
                                }
                            }

                        }
                    }

                    //Console.WriteLine("After loop");

                    //foreach (List<Point> path in paths)
                    //{
                    //    foreach (Point p in path)
                    //    {
                    //        Console.Write(p.ToString() + " ");
                    //    }

                    //    Console.WriteLine();
                    //}

                    //Console.WriteLine();
                    //Console.WriteLine();
                }
                while (!found && paths.Any());

                return paths;
            }

            private bool NextToEnemy(Point point, int type)
            {
                List<Point> candidates = new List<Point>
                {
                    new Point(point.X + 1, point.Y),
                    new Point(point.X - 1, point.Y),
                    new Point(point.X, point.Y + 1),
                    new Point(point.X, point.Y - 1)
                };

                foreach (Point check in candidates)
                {
                    if (raster[check.X, check.Y].Combat != null && raster[check.X, check.Y].Combat.Type == type)
                    {
                        return true;
                    }
                }

                return false;
            }

            public void Debug()
            {
                int width = raster.GetLength(0);
                int heigth = raster.GetLength(1);

                for (int j = 0; j < heigth; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        RasterElement r = raster[i, j];

                        if (r.Wall)
                        {
                            Console.Write('#');
                        }
                        else if (r.Combat == null)
                        {
                            Console.Write('.');
                        }
                        else if (r.Combat.Type == 1)
                        {
                            Console.Write('E');
                        }
                        else if (r.Combat.Type == 2)
                        {
                            Console.Write('G');
                        }
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine("Combats");
                Console.WriteLine("=======");
                Console.WriteLine();

                foreach (Combat c in combats)
                {
                    c.Debug();
                }

                Console.WriteLine();
                Console.WriteLine();
            }

            public class Combat : Point
            {
                int type;

                int hitPoints;

                public Combat(long x,  long y, int type)
                    : base(x, y)
                {
                    this.Type = type;

                    this.HitPoints = 200;
                }

                public int Type { get => type; set => type = value; }
                public int HitPoints { get => hitPoints; set => hitPoints = value; }

                internal void Debug()
                {
                    switch(type)
                    {
                        case 1:
                            Console.Write("Elve   ");
                            break;
                        case 2:
                            Console.Write("Goblin ");
                            break;
                    }

                    Console.Write(string.Format("({0}, {1}) => {2}", this.X, this.Y, this.HitPoints));

                    Console.WriteLine();
                }
            }

            public class RasterElement : Point
            {
                bool wall;

                Combat combat;

                public RasterElement(long x, long y, bool wall, Combat combat)
                    : base(x, y)
                {
                    this.wall = wall;

                    this.Combat = combat;
                }

                public bool Wall { get => wall; internal set => wall = value; }
                public Combat Combat { get => combat; set => combat = value; }

                public bool Free()
                {
                    return !Wall && combat == null;
                }
            }
        }
    }
}
