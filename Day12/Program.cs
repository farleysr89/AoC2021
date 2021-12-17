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
            var input = File.ReadAllText("testInput.txt");
            var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            var paths = lines.Select(l => l.Split("-")).Select(p => new Path { ends = new End[] { new() { name = p[0] }, new() { name = p[1] } } }).ToList();
            paths.AddRange(lines.Select(l => l.Split("-")).Select(p => new Path { ends = new End[] { new() { name = p[1] }, new() { name = p[0] } } }).ToList());
            var count = 0;
            foreach (var p in paths.Where(pp => pp.ends[0].start))
            {
                count += CountPaths(paths, p, "start", new List<string>());
            }
            Console.WriteLine("Solution 1 is " + count);
        }

        static int CountPaths(List<Path> paths, Path path, string position, List<string> visited)
        {
            var count = 0;
            visited.Add(position);
            var destination = path.ends[1].name;
            visited.Add(destination);
            if (path.ends.Any(e => e.end)) return 1;
            foreach (var p in paths.Where(pp => pp.ends[0].name == destination && !visited.Contains(pp.ends[1].name) || pp.ends[1].large))
            {
                count += CountPaths(paths, p, destination, visited);
            }
            return count;
        }

        static void Part2()
        {

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