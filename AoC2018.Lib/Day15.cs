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

                Console.Clear();
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

                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        RasterElement re = raster[i, j];

                        if (i > 0)
                        {
                            re.Left = raster[i - 1, j];
                        }

                        if (j > 0)
                        {
                            re.Up = raster[i, j - 1];
                        }

                        if (i < width - 1)
                        {
                            re.Right = raster[i + 1, j];
                        }

                        if (j < height - 1)
                        {
                            re.Down = raster[i, j + 1];
                        }
                    }
                }
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

                    this.Move(raster[c.X, c.Y]);

                    this.Attack(raster[c.X, c.Y]);
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

            private void Attack(RasterElement re)
            {
                if (re.Combat == null) return;

                Combat c = re.Combat;

                if (c.HitPoints < 0)
                {
                    return;
                }

                int type = 1;

                if (c.Type == 1)
                {
                    type = 2;
                }

                List<RasterElement> enemies = GetEnemies(re, type);

                enemies.Sort(this.CompareEnemies);

                if (!enemies.Any())
                {
                    return;
                }

                RasterElement target = enemies.First();

                target.Combat.HitPoints -= 3;

                if (target.Combat.HitPoints < 0)
                {
                    //Console.Write("KILL ");
                    //target.Combat.Debug();

                    combats.Remove(target.Combat);

                    target.Combat = null;
                }
            }

            private int CompareEnemies(RasterElement x, RasterElement y)
            {
                int hitCompare = x.Combat.HitPoints.CompareTo(y.Combat.HitPoints);

                if (hitCompare != 0)
                {
                    return hitCompare;
                }

                return Util.ComparePoints(x, y);
            }

            private List<RasterElement> GetEnemies(RasterElement point, int type)
            {
                RasterElement[] candidates = 
                {
                    point.Down,
                    point.Left,
                    point.Up,
                    point.Right
                };

                List<RasterElement> enemies = new List<RasterElement>();
                 
                foreach (RasterElement check in candidates)
                {
                    if (check == null) continue;

                    if (check.Combat != null && check.Combat.Type == type)
                    {
                        enemies.Add(check);
                    }
                }

                return enemies;
            }

            private void Move(RasterElement re)
            {
                if (re.Combat == null) return;

                Combat c = re.Combat;

                if (c.HitPoints < 0)
                {
                    return;
                }

                int type = 1;

                if (c.Type == 1)
                {
                    type = 2;
                }

                if (NextToEnemy(re, type)) {
                    return;
                }

                List<List<RasterElement>> paths = ShortestPathToEnemy(re);

                if (paths.Count == 0)
                {
                    // no possible move
                    return;
                }

                paths.Sort((x, y) => Util.ComparePoints(x.Last(), y.Last()));

                RasterElement last = paths.First().Last();

                SortedSet<RasterElement> steps = new SortedSet<RasterElement>();

                foreach (List<RasterElement> p in paths)
                {
                    if (p.Last().X == last.X && p.Last().Y == last.Y)
                    {
                        steps.Add(p[1]);
                    }
                }

                //Point step = paths.First()[1];
                RasterElement step = steps.First();

                //c.Debug();
                //Console.WriteLine("Move to " + step.ToString());

                re.Combat = null;

                step.Combat = c;

                c.X = step.X;
                c.Y = step.Y;
            }

            private List<List<RasterElement>> ShortestPathToEnemy(RasterElement re)
            {
                Combat c = re.Combat;

                int type = 1;

                if (c.Type == 1)
                {
                    type = 2;
                }

                List<List<RasterElement>> paths = new List<List<RasterElement>>();

                List<RasterElement> basePath = new List<RasterElement>
                {
                    re
                };

                paths.Add(basePath);

                bool found = false;

                HashSet<string> nodes = new HashSet<string>();
                nodes.Add(basePath.First().ToString());

                do
                {
                    //Console.WriteLine("path " + paths.First().Count() + " " + paths.Count() + " " +paths.First().First());

                    List<List<RasterElement>> old = paths;

                    paths = new List<List<RasterElement>>();

                    HashSet<String> added = new HashSet<String>();

                    foreach (List<RasterElement> path in old)
                    {
                        RasterElement last = path.Last();

                        RasterElement[] candidates = 
                        {
                            last.Up,
                            last.Right,
                            last.Down,
                            last.Left
                        };

                        foreach (RasterElement candidate in candidates)
                        {
                            if (candidate == null) continue;

                            if (candidate.Free())
                            {
                                bool notProcessedBefore = !nodes.Contains(candidate.ToString());

                                if (notProcessedBefore)
                                {
                                    List<RasterElement> newPath = new List<RasterElement>(path)
                                    {
                                        candidate
                                    };

                                    bool enemy = this.NextToEnemy(candidate, type);

                                    if (enemy && !found)
                                    {
                                        found = true;

                                        paths.Clear();

                                        paths.Add(newPath);
                                    }
                                    else if ((enemy && found) || !found)
                                    {
                                        paths.Add(newPath);

                                        added.Add(candidate.ToString());
                                    }
                                }
                            }
                        }
                    }

                    foreach (String add in added)
                    {
                        nodes.Add(add);
                    }
                }
                while (!found && paths.Any());

                return paths;
            }

            private bool NextToEnemy(RasterElement point, int type)
            {
                RasterElement[] candidates = 
                {
                    point.Up,
                    point.Right,
                    point.Down,
                    point.Left
                };

                foreach (RasterElement check in candidates)
                {
                    if (check == null) continue;

                    if (check.Combat != null && check.Combat.Type == type)
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

                int k = 0;

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

                    if (k < combats.Count())
                    {
                        Console.Write("    ");
                        combats[k].Debug();
                        k++;
                    }

                    Console.WriteLine();
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
                }
            }

            public class RasterElement : Point
            {
                bool wall;

                Combat combat;

                RasterElement up;
                RasterElement down;
                RasterElement left;
                RasterElement right;

                public RasterElement(long x, long y, bool wall, Combat combat)
                    : base(x, y)
                {
                    this.wall = wall;

                    this.Combat = combat;
                }

                public bool Wall { get => wall; internal set => wall = value; }
                public Combat Combat { get => combat; set => combat = value; }

                public RasterElement Up { get => up; set => up = value; }
                public RasterElement Down { get => down; set => down = value; }
                public RasterElement Left { get => left; set => left = value; }
                public RasterElement Right { get => right; set => right = value; }

                public bool Free()
                {
                    return !Wall && combat == null;
                }
            }
        }
    }
}
