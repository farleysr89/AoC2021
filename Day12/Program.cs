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
            var paths = lines.Select(l => l.Split("-")).Select(p => new Path { ends = new End[] { new() { name = p[0] }, new() { name = p[1] } } }).ToList();
            paths.AddRange(lines.Select(l => l.Split("-")).Select(p => new Path { ends = new End[] { new() { name = p[1] }, new() { name = p[0] } } }).ToList());
            var count = paths.Where(pp => pp.ends[0].start).Sum(p => CountPaths(paths, p, new List<string> { "start" }));
            Console.WriteLine("Solution 1 is " + count);
        }

        static int CountPaths(List<Path> paths, Path path, List<string> visited)
        {
            var position = path.ends[1].name;
            visited.Add(position);
            return path.ends[1].end ? 1 : paths.Where(pp => pp.ends[0].name == position && (!visited.Contains(pp.ends[1].name) || pp.ends[1].large)).Sum(p => CountPaths(paths, p, new List<string>(visited)));
        }

        static void Part2()
        {
            var input = File.ReadAllText("input.txt");
            var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            var paths = lines.Select(l => l.Split("-")).Select(p => new Path { ends = new End[] { new() { name = p[0] }, new() { name = p[1] } } }).ToList();
            paths.AddRange(lines.Select(l => l.Split("-")).Select(p => new Path { ends = new End[] { new() { name = p[1] }, new() { name = p[0] } } }).ToList());
            var count = paths.Where(pp => pp.ends[0].start).Sum(p => CountPaths2(paths, p, new List<string> { "start" }, false));
            Console.WriteLine("Solution 2 is " + count);
        }

        static int CountPaths2(List<Path> paths, Path path, List<string> visited, bool visitedTwice)
        {
            var position = path.ends[1].name;
            visited.Add(position);
            return path.ends[1].end ? 1 : 
                paths.Where(pp => !pp.ends[1].start && 
                                  pp.ends[0].name == position 
                                  && (!visited.Contains(pp.ends[1].name) || pp.ends[1].large || !visitedTwice))
                    .Sum(p => CountPaths2(paths, p, new List<string>(visited),visitedTwice || visited.Any(v => v == v.ToLower() && p.ends[1].name == v)));
        }
    }

    internal class Path
    {
        internal End[] ends = new End[2];
    }

    internal class End
    {
        internal string name;
        internal bool large=> name == name.ToUpper();
        internal bool start => name == "start";
        internal bool end => name == "end";
    }
}