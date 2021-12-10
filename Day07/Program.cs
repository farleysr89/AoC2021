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
            var entries = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
            var positions = entries[0].Split(",").Select(i => Convert.ToInt32(i)).ToList();
            positions.Sort();
            var mid = positions[positions.Count / 2];
            var cost = positions.Sum(p => Math.Abs(p - mid));

            Console.WriteLine("Solution 1 = " + cost);
        }

        static void Part2()
        {
            var input = File.ReadAllText("input.txt");
            var entries = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
            var positions = entries[0].Split(",").Select(i => Convert.ToInt32(i)).ToList();
            positions.Sort();
            var cost = int.MaxValue;
            var index = -1;
            for (var i = positions.Min(); i <= positions.Max(); i++)
            {
                var temp = positions.Sum(p =>
                {
                    var dist = Math.Abs(p - i);
                    var cost = Enumerable.Range(1, dist).Sum(i => i);
                    return cost;
                });
                if (temp < cost)
                {
                    cost = temp;
                    index = i;
                }
            }
            Console.WriteLine("Solution 2 = " + cost);
        }
    }
}