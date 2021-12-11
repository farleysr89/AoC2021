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
            var outputs = input.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            var total = 0;
            for (var i = 0; i < outputs.Count; i++)
            {
                for (var j = 0; j < outputs[i].Length; j++)
                {
                    var k = Convert.ToInt32(outputs[i][j].ToString());
                    if (i != 0)
                    {
                        if (Convert.ToInt32(outputs[i - 1][j].ToString()) <= k) continue;
                    }

                    if (j != 0)
                    {
                        if (Convert.ToInt32(outputs[i][j - 1].ToString()) <= k) continue;
                    }

                    if (i != outputs.Count - 1)
                    {
                        if (Convert.ToInt32(outputs[i + 1][j].ToString()) <= k) continue;
                    }

                    if (j != outputs[i].Length - 1)
                    {
                        if (Convert.ToInt32(outputs[i][j + 1].ToString()) <= k) continue;
                    }

                    total += k + 1;
                }
            }

            Console.WriteLine("Solution 1 is " + total);
        }

        static void Part2()
        {
            var input = File.ReadAllText("input.txt");
            var outputs = input.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            var points = new List<Point>();
            for (var i = 0; i < outputs.Count; i++)
            {
                for (var j = 0; j < outputs[i].Length; j++)
                {
                    points.Add(new Point
                    {
                        x = j,
                        y = i,
                        value = Convert.ToInt32(outputs[i][j].ToString())
                    });
                }
            }

            var sizes = new List<int>();
            for (var i = 0; i < outputs.Count; i++)
            {
                for (var j = 0; j < outputs[i].Length; j++)
                {
                    var p = points.First(p => p.x == j && p.y == i);
                    if (p.marked || p.value == 9) continue;
                    var size = 0;
                    var pointsToVisit = new Queue<Point>();
                    pointsToVisit.Enqueue(p);
                    while (pointsToVisit.Count > 0)
                    {
                        var point = pointsToVisit.Dequeue();
                        size++;
                        point.marked = true;
                        Point newPoint;
                        if (points.Any(pp => pp.x == point.x - 1 && pp.y == point.y && !pp.marked && pp.value != 9))
                        {
                            newPoint = points.First(pp =>
                                pp.x == point.x - 1 && pp.y == point.y && !pp.marked && pp.value != 9);
                            if(!pointsToVisit.Contains(newPoint))
                                pointsToVisit.Enqueue(newPoint);
                        }

                        if (points.Any(pp => pp.x == point.x && pp.y == point.y - 1 && !pp.marked && pp.value != 9))
                        {
                            newPoint = points.First(pp =>
                                pp.x == point.x && pp.y == point.y - 1 && !pp.marked && pp.value != 9);
                            if(!pointsToVisit.Contains(newPoint))
                                pointsToVisit.Enqueue(newPoint);
                        }

                        if (points.Any(pp => pp.x == point.x + 1 && pp.y == point.y && !pp.marked && pp.value != 9))
                        {
                            newPoint = points.First(pp =>
                                pp.x == point.x + 1 && pp.y == point.y && !pp.marked && pp.value != 9);
                            if(!pointsToVisit.Contains(newPoint))
                                pointsToVisit.Enqueue(newPoint);
                        }

                        if (points.Any(pp => pp.x == point.x && pp.y == point.y + 1 && !pp.marked && pp.value != 9))
                        {
                            newPoint = points.First(pp =>
                                pp.x == point.x && pp.y == point.y + 1 && !pp.marked && pp.value != 9);
                            if(!pointsToVisit.Contains(newPoint))
                                pointsToVisit.Enqueue(newPoint);
                        }
                    }
                    sizes.Add(size);
                }
            }

            var sortedSizes = sizes.OrderByDescending(s => s).ToList();
            var a = sortedSizes[0];
            var b = sortedSizes[1];
            var c = sortedSizes[2];
            Console.WriteLine("Solution 2 is " + a * b * c);
        }

    }

    internal class Point
    {
        internal int x;
        internal int y;
        internal int value;
        internal bool marked = false;
    }
}