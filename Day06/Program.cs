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
            var entries = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
            var fish = entries[0].Split(",").Select(i => new LanternFish
            {
                count = Convert.ToInt32(i)
            }).ToList();
            for (var i = 0; i < 80; i++)
            {
                var addCount = 0;
                foreach (var f in fish)
                {
                    f.count--;
                    if (f.count == -1)
                    {
                        f.count = 6;
                        addCount++;
                    }
                }
                for(var j = 0; j < addCount; j++)
                    fish.Add(new LanternFish{count = 8});
            }
            Console.WriteLine("Solution 1 = " + fish.Count);
        }

        static void Part2()
        {
            var input = File.ReadAllText("input.txt");
            var entries = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
            var fish = entries[0].Split(",").Select(i => Convert.ToInt32(i)).ToList();
            var totals = new Dictionary<int, long>();
            foreach(var f in fish)
            {
                totals.TryGetValue(f, out var currentCount);
                totals[f] = currentCount + 1;
            }
            for (var i = 0; i < 256; i++)
            {
                var newTotals = new Dictionary<int, long>();
                long addCount = 0;
                foreach(var f in totals)
                {
                    if (f.Key == 0)
                    {
                        newTotals.Add(6, f.Value);
                        addCount = f.Value;
                    }
                    else
                    {
                        newTotals.TryGetValue(f.Key - 1, out var currentCount);
                        newTotals[f.Key - 1] = currentCount + f.Value;
                    }
                }
                newTotals[8] = addCount;
                totals = new Dictionary<int,long>(newTotals);
            }
            Console.WriteLine("Solution 2 = " + totals.Sum(t => t.Value));
        }
    }

    internal class LanternFish
    {
        internal int count;
    }
}