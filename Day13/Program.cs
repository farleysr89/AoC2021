namespace AoC2021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        static void Part1()
        {
            var input = File.ReadAllText("input.txt");
            var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            var folds = new List<Fold>();
            var points = new List<Point>();
            foreach (var line in lines)
            {
                if (line.Contains("fold along x"))
                {
                    var parts = line.Split("=");
                    folds.Add(new Fold
                    {
                        x = true,
                        value = int.Parse(parts[1])
                    });
                }                
                else if (line.Contains("fold along y"))
                {
                    var parts = line.Split("=");
                    folds.Add(new Fold
                    {
                        x = false,
                        value = int.Parse(parts[1])
                    });
                }
                else
                {
                    var parts = line.Split(",");
                    points.Add(new Point
                    {
                        x = int.Parse(parts[0]),
                        y = int.Parse(parts[1])
                    });
                }
            }

            var fold = folds.First();
            if (fold.x)
            {
                foreach (var point in points)
                {
                    if (point.x <= fold.value) continue;
                    var newX = point.x - (point.x - fold.value) * 2;
                    if (points.Any(p => p.x == newX && p.y == point.y))
                    {
                        point.duplicate = true;
                    }

                    point.x = newX;
                }
            }
            else
            {
                foreach (var point in points)
                {
                    if (point.y <= fold.value) continue;
                    var newY = point.y - (point.y - fold.value) * 2;
                    if (points.Any(p => p.y == newY && p.x == point.x))
                    {
                        point.duplicate = true;
                    }

                    point.y = newY;
                }
            }
            Console.WriteLine("Solution 1 is " + points.Count(p => !p.duplicate));
        }

        static void Part2()
        {
            var input = File.ReadAllText("input.txt");
            var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            var folds = new List<Fold>();
            var points = new List<Point>();
            foreach (var line in lines)
            {
                if (line.Contains("fold along x"))
                {
                    var parts = line.Split("=");
                    folds.Add(new Fold
                    {
                        x = true,
                        value = int.Parse(parts[1])
                    });
                }                
                else if (line.Contains("fold along y"))
                {
                    var parts = line.Split("=");
                    folds.Add(new Fold
                    {
                        x = false,
                        value = int.Parse(parts[1])
                    });
                }
                else
                {
                    var parts = line.Split(",");
                    points.Add(new Point
                    {
                        x = int.Parse(parts[0]),
                        y = int.Parse(parts[1])
                    });
                }
            }

            foreach (var fold in folds)
            {
                if (fold.x)
                {
                    foreach (var point in points.Where(p => !p.duplicate))
                    {
                        if (point.x <= fold.value) continue;
                        var newX = point.x - (point.x - fold.value) * 2;
                        if (points.Any(p => p.x == newX && p.y == point.y))
                        {
                            point.duplicate = true;
                        }

                        point.x = newX;
                    }
                }
                else
                {
                    foreach (var point in points.Where(p => !p.duplicate))
                    {
                        if (point.y <= fold.value) continue;
                        var newY = point.y - (point.y - fold.value) * 2;
                        if (points.Any(p => p.y == newY && p.x == point.x))
                        {
                            point.duplicate = true;
                        }

                        point.y = newY;
                    }
                }
            }

            var output = points.Where(p=>!p.duplicate).GroupBy(p => p.y).ToList();
            var outputLines = output.OrderBy(o => o.Key);
            var printLines = new List<string>();
            var size = points.Where(p=>!p.duplicate).Max(p => p.x);
            foreach (var line in outputLines)
            {
                var printLine = "";
                for (var i = 0; i <= size; i++)
                {
                    if (line.Any(p => p.x == i))
                        printLine += "#";
                    else
                        printLine += ".";
                }
                printLines.Add(printLine);
            }


            Console.WriteLine("Solution 2 is ");
            foreach(var p in printLines)
                Console.WriteLine(p);
        }
    }

    internal class Point
    {
        internal int x;
        internal int y;
        internal bool duplicate = false;
    }

    internal class Fold
    {
        internal bool x;
        internal int value;
    }
}