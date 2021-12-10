namespace AoC2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        static void Part1()
        {
            var input = File.ReadAllText("input.txt");
            var entries = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
            var lines = new List<Line>();
            foreach (var e in entries)
            {
                var split = e.Split(" -> ");
                var first = split[0].Split(",");
                var second = split[1].Split(",");
                lines.Add(new Line
                {
                    point1 = new Point
                    {
                        x = Convert.ToInt32(first[0]),
                        y = Convert.ToInt32(first[1])
                    },
                    point2 = new Point
                    {
                        x = Convert.ToInt32(second[0]),
                        y = Convert.ToInt32(second[1])
                    }
                });
            }

            var straightLines = lines.Where(l => l.horizontal || l.vertical).ToList();
            var points = new Dictionary<(int, int),int>();
            foreach (var l in straightLines.Where(ll => ll.horizontal))
            {
                var y = l.point1.y;
                if (l.point1.x < l.point2.x)
                {
                    for (var i = l.point1.x; i <= l.point2.x; i++)
                    {
                        var id = (i, y);
                        points.TryGetValue(id, out var currentCount);
                        points[id] = currentCount + 1;
                    }
                }
                else
                {
                    for (var i = l.point2.x; i <= l.point1.x; i++)
                    {
                        var id = (i, y);
                        points.TryGetValue(id, out var currentCount);
                        points[id] = currentCount + 1;
                    }
                }
            }
            foreach (var l in straightLines.Where(ll => ll.vertical))
            {
                var x = l.point1.x;
                if (l.point1.y < l.point2.y)
                {
                    for (var i = l.point1.y; i <= l.point2.y; i++)
                    {
                        var id = (x, i);
                        points.TryGetValue(id, out var currentCount);
                        points[id] = currentCount + 1;
                    }
                }
                else
                {
                    for (var i = l.point2.y; i <= l.point1.y; i++)
                    {
                        var id = (x, i);
                        points.TryGetValue(id, out var currentCount);
                        points[id] = currentCount + 1;
                    }
                }
            }
            Console.WriteLine("Solution 1 = " + points.Count(p => p.Value > 1));
        }

        static void Part2()
        {
            var input = File.ReadAllText("input.txt");
            var entries = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
            var lines = new List<Line>();
            foreach (var e in entries)
            {
                var split = e.Split(" -> ");
                var first = split[0].Split(",");
                var second = split[1].Split(",");
                lines.Add(new Line
                {
                    point1 = new Point
                    {
                        x = Convert.ToInt32(first[0]),
                        y = Convert.ToInt32(first[1])
                    },
                    point2 = new Point
                    {
                        x = Convert.ToInt32(second[0]),
                        y = Convert.ToInt32(second[1])
                    }
                });
            }

            var points = new Dictionary<(int, int),int>();
            foreach (var l in lines.Where(ll => ll.horizontal))
            {
                var y = l.point1.y;
                if (l.point1.x < l.point2.x)
                {
                    for (var i = l.point1.x; i <= l.point2.x; i++)
                    {
                        var id = (i, y);
                        points.TryGetValue(id, out var currentCount);
                        points[id] = currentCount + 1;
                    }
                }
                else
                {
                    for (var i = l.point2.x; i <= l.point1.x; i++)
                    {
                        var id = (i, y);
                        points.TryGetValue(id, out var currentCount);
                        points[id] = currentCount + 1;
                    }
                }
            }
            foreach (var l in lines.Where(ll => ll.vertical))
            {
                var x = l.point1.x;
                if (l.point1.y < l.point2.y)
                {
                    for (var i = l.point1.y; i <= l.point2.y; i++)
                    {
                        var id = (x, i);
                        points.TryGetValue(id, out var currentCount);
                        points[id] = currentCount + 1;
                    }
                }
                else
                {
                    for (var i = l.point2.y; i <= l.point1.y; i++)
                    {
                        var id = (x, i);
                        points.TryGetValue(id, out var currentCount);
                        points[id] = currentCount + 1;
                    }
                }
            }
            foreach (var l in lines.Where(ll => !ll.vertical && !ll.horizontal))
            {
                if (l.point1.y < l.point2.y)
                {
                    if (l.point1.x < l.point2.x)
                    {
                        var count = 0;
                        for (var i = l.point1.x; i <= l.point2.x; i++)
                        {
                            var id = (i, l.point1.y + count);
                            points.TryGetValue(id, out var currentCount);
                            points[id] = currentCount + 1;
                            count++;
                        }
                    }
                    else
                    {
                        var count = 0;
                        for (var i = l.point2.x; i <= l.point1.x; i++)
                        {
                            var id = (i, l.point2.y - count);
                            points.TryGetValue(id, out var currentCount);
                            points[id] = currentCount + 1;
                            count++;
                        }
                    }
                }
                else
                {
                    if (l.point1.x < l.point2.x)
                    {
                        var count = 0;
                        for (var i = l.point1.x; i <= l.point2.x; i++)
                        {
                            var id = (i, l.point1.y - count);
                            points.TryGetValue(id, out var currentCount);
                            points[id] = currentCount + 1;
                            count++;
                        }
                    }
                    else
                    {
                        var count = 0;
                        for (var i = l.point2.x; i <= l.point1.x; i++)
                        {
                            var id = (i, l.point2.y + count);
                            points.TryGetValue(id, out var currentCount);
                            points[id] = currentCount + 1;
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine("Solution 2 = " + points.Count(p => p.Value > 1));
        }
    }

    internal class Point
    {
        internal int x;
        internal int y;
    }

    internal class Line
    {
        internal Point point1;
        internal Point point2;
        internal bool horizontal => point1.y == point2.y;
        internal bool vertical => point1.x == point2.x;
    }
}