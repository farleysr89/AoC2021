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
            var parts = outputs.Select(o => o.Split(" | ")).Select(s => s[1]).SelectMany(s => s.Split(" ")).ToList();
            var count = parts.Count(o => o.Length is 2 or 3 or 4 or 7);
            Console.WriteLine("Solution 1 = " + count);
        }

        static void Part2()
        {

        }
    }
}